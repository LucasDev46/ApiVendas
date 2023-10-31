using System.Linq.Expressions;

namespace Loja.Repository.Interface;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    Task<T> GetByQuery(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);

}
