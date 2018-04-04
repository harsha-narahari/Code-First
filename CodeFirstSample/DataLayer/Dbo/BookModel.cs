namespace CodeFirstSample.DataLayer.Dbo
{
    using System;
    using System.Data.Entity;
    using CodeFirstSample.DataLayer.Dbo.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookModel : DbContext
    {
        public BookModel()
            : base("name=BookModel")
        {
        }

        public virtual DbSet<tblBook> tblBooks { get; set; }
        public virtual DbSet<tblBookDetail> tblBookDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBook>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblBook>()
                .HasMany(e => e.tblBookDetails)
                .WithRequired(e => e.tblBook)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblBookDetail>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<tblBookDetail>()
                .Property(e => e.Publisher)
                .IsUnicode(false);
        }
    }
}
