using GloveWizard.Infrastructure.Entities;
using System.Linq.Expressions;

namespace GloveWizard.Infrastructure.Interfaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(T entity);
    }
}
