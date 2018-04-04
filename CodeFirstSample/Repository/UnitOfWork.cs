using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSample.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        protected List<string> _procedures;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        protected static Lazy<IRepository<TEntity>> GetLazyRepository<TEntity>(DbContext context) where TEntity : class
        {
            return new Lazy<IRepository<TEntity>>(() => new Repository<TEntity>(context));
        }

        public List<T> ExecuteSelectProcedure<T>(string procedureName, object[] parameters)
        {
            List<T> result = null;
            if (_procedures != null && _procedures.Count != 0)
            {
                var query = _procedures.FirstOrDefault(q => q.Contains(procedureName));
                if (!string.IsNullOrEmpty(query))
                {
                    result = _context.Database.SqlQuery<T>(query, parameters).ToList();
                }
            }
            return result;
        }

        public int ExecuteCommandProcedure(string procedureName, object[] Params)
        {
            var affectedRows = 0;
            if (_procedures != null && _procedures.Count != 0)
            {
                var query = _procedures.FirstOrDefault(q => q.Contains(procedureName));
                if (!string.IsNullOrEmpty(query))
                {
                    affectedRows = _context.Database.ExecuteSqlCommand(query, Params);
                }
            }
            return affectedRows;
        }

        public void Save()
        {
            if (_context != null)
            {
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (_disposed == false && disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
