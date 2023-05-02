using GloveWizard.Data.Contexts;
using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Infrastructure.Interfaces.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace GloveWizard.Infrastructure.Repositorys
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(
            DataContext context,
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
             await dbSet.AddAsync(entity);
            return entity;
            
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbSet.AsNoTracking().Where(expression);
        }

        public  IEnumerable<T> GetAll()
        {
            return dbSet.ToList();

        }

        public T? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public  bool Remove(int id)
        {
            var entity = dbSet.Find(id);

            if (entity != null)
            {
                dbSet.Remove(entity);
                return true;
            }

            return false;
        }

        public bool Update(T obj)
        {
            var entry = dbSet.Entry(obj);
            entry.CurrentValues.SetValues(obj);
            entry.State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }
    }


}


