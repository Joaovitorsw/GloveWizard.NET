
using GloveWizard.Infrastructure.Entities;
using System.Linq.Expressions;

namespace GloveWizard.Infrastructure.Interfaces.IGenericRepository
{ 
  public interface  IGenericRepository<T> where T : class
    {
    T? GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    Task<T> Add(T entity);
    bool Remove(int id);
    bool Update(T entity);
}

}
