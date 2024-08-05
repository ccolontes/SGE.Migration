using System.Linq.Expressions;

using SGE.Domain.Common.Interfaces.Models;

namespace SGE.Domain.Common.Interfaces.Persistence;

public interface IGenericRepository<T>
    where T : class, IAggregateRoot
{
    ICollection<T> GetAll(string includes = "");
    T? GetById(string key);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    T? FirstOrDefault(Expression<Func<T, bool>> predicate);
    ICollection<T> Where(Expression<Func<T, bool>> predicate, string includes = "");
    void Update(T entity);
    void Add(T entity);
    void Delete(T entity);
}
