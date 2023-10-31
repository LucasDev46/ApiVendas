using System.Linq.Expressions;

namespace Loja.Repository.Interface;

public interface IRepository<T>
{
    IQueryable<T> SelectAll();
    Task<T> SelectByQuery(Expression<Func<T, bool>> predicate);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);

}
