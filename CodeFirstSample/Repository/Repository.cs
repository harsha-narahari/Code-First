using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSample.Repository
{
    [ExcludeFromCodeCoverage]
    public partial class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public T Insert(T obj)
        {
            return dbSet.Add(obj);
        }

        public void Delete(object Id)
        {
            T instance = dbSet.Find(Id);
            dbSet.Remove(instance);
        }

        public T Update(T obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }
    }
}
