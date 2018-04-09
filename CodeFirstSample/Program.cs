using CodeFirstSample.DataLayer.Dbo;
using CodeFirstSample.DomainModel.Dbo;
using System;

namespace CodeFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            BookUnitOfWork uow = new BookUnitOfWork(new BookModel());
            AddBooks(uow);
            GetBooks(uow);
        }

        private static void GetBooks(BookUnitOfWork uow)
        {
            var books = uow.ExecuteSelectProcedure<BookSummary>("spGetBooks", new object[] { "" });

            foreach (var book in books)
            {
                Console.WriteLine("Name {0}, Author {1}, Publisher {2}", book.BookName, book.Author, book.Publisher);
            }
            Console.ReadLine();
        }

        private static void AddBooks(BookUnitOfWork uow)
        {
            //var book = uow.tblBooks.Insert(new tblBook() { Name = "A" });
            //uow.tblBookDetails.Insert(new tblBookDetail() { Author = "Author1", BookID = book.BookID, Publisher = "P1", tblBook = book });

            //book = uow.tblBooks.Insert(new tblBook() { Name = "B" });
            //uow.tblBookDetails.Insert(new tblBookDetail() { Author = "Author2", BookID = book.BookID, Publisher = "P1", tblBook = book });

            //book = uow.tblBooks.Insert(new tblBook() { Name = "C" });
            //uow.tblBookDetails.Insert(new tblBookDetail() { Author = "Author3", BookID = book.BookID, Publisher = "P1", tblBook = book });

            uow.ExecuteCommandProcedure("spInsertBook", new object[] { "A", "Author1", "P1" });
            uow.ExecuteCommandProcedure("spInsertBook", new object[] { "B", "Author1", "P2" });
            uow.ExecuteCommandProcedure("spInsertBook", new object[] { "C", "Author2", "P2" });
            uow.ExecuteCommandProcedure("spInsertBook", new object[] { "D", "Author2", "P1" });
            uow.ExecuteCommandProcedure("spInsertBook", new object[] { "E", "Author3", "P1" });

            uow.Save();



        }
    }
}
