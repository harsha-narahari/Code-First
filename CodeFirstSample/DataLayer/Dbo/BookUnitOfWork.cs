using CodeFirstSample.DataLayer.Dbo.Entity;
using CodeFirstSample.DomainModel.Dbo;
using CodeFirstSample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSample.DataLayer.Dbo
{
    public partial class BookUnitOfWork : UnitOfWork
    {
        private BookModel _context;


        public BookUnitOfWork(BookModel context)
            : base(context)
        {
            _context = context;
            _tblBooks = GetLazyRepository<tblBook>(context);
            _tblBookDetails = GetLazyRepository<tblBookDetail>(context);
            PopulateProcedures();
        }

        private void PopulateProcedures()
        {
            _procedures = new List<string>()
                            {
                                "EXEC dbo.spGetBooks @Name={0}",
                                "EXEC dbo.spInsertBook @Name={0}, @Author={1}, @Publisher={2}"
                            };
        }

        private Lazy<IRepository<tblBook>> _tblBooks;
        private Lazy<IRepository<tblBookDetail>> _tblBookDetails;

        public IRepository<tblBook> tblBooks
        {
            get { return _tblBooks.Value; }
        }

        public IRepository<tblBookDetail> tblBookDetails
        {
            get { return _tblBookDetails.Value; }
        }

        public List<BookSummary> GetBookBookSummary()
        {
            //var query = _context.Database.SqlQuery<BookSummary>(string.Format("dbo.spGetBooks {0}", "A"));
            var query = _context.Database.SqlQuery<BookSummary>("EXEC dbo.spGetBooks @Name={0}", "A");
            return query.ToList();
        }
    }
}
