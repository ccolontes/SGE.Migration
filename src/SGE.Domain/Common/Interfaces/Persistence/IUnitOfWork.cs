using SGE.Domain.Common.Interfaces.Models;

namespace SGE.Domain.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task BeginTransaction();
    Task CommitAsync();
    Task RollbackAsync(CancellationToken cancellationToken);
    IGenericRepository<T> GenericRepository<T>()
        where T : class, IAggregateRoot;
}