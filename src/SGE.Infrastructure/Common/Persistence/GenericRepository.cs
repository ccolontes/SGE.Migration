using System.Collections.Immutable;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using SGE.Domain.Common.Interfaces.Models;
using SGE.Domain.Common.Interfaces.Persistence;

namespace SGE.Infrastructure.Common.Persistence;

public class GenericRepository<T>(DbContext context) : IGenericRepository<T>
    where T : class, IAggregateRoot
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public ICollection<T> GetAll(string includes = "")
    {
        var query = _dbSet.AsNoTracking();

        if (!string.IsNullOrEmpty(includes))
        {
            var entities = includes.Split(';');
            foreach (var entity in entities)
            {
                query = query.Include(entity);
            }
        }

        return query.AsNoTracking().ToImmutableList();
    }

    public T? GetById(string key)
    {
        return _dbSet.Find(new object[] { key });
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public T? FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.FirstOrDefault(predicate);
    }

    public ICollection<T> Where(Expression<Func<T, bool>> predicate, string includes = "")
    {
        var query = _dbSet.Where(predicate);

        if (string.IsNullOrEmpty(includes))
        {
            return query.AsNoTracking().ToImmutableList();
        }

        var entities = includes.Split(';');
        foreach (var entity in entities)
        {
            query = query.Include(entity);
        }

        return query.AsNoTracking().ToImmutableList();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}