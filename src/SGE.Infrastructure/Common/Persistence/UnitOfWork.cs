using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using SGE.Domain.Common.Interfaces.Models;
using SGE.Domain.Common.Interfaces.Persistence;
using SGE.Infrastructure.Common.Interfaces;

namespace SGE.Infrastructure.Common.Persistence;

public class UnitOfWork<T>(T context) : IUnitOfWork<T>
    where T : DbContext
{
    private IDbContextTransaction? _transaction;

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
       await context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransaction()
    {
        _transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.CommitAsync();
        }

        await context.SaveChangesAsync();
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
       await context.Database.RollbackTransactionAsync(cancellationToken);
    }

    public IGenericRepository<TD> GenericRepository<TD>()
        where TD : class, IAggregateRoot
    {
        return new GenericRepository<TD>(context);
    }
}