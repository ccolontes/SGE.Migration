using Microsoft.EntityFrameworkCore;
using SGE.Application.Common.Interfaces;
using SGE.Domain.Users;
using SGE.Infrastructure.Common;
using SGE.Infrastructure.Common.Persistence;

namespace SGE.Infrastructure.Users.Persistence;

public class UsersRepository(AppDbContext _dbContext) : IUsersRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FindAsync(userId, cancellationToken);
    }

    public async Task<User?> GetBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Subscription.Id == subscriptionId, cancellationToken);
    }

    public async Task RemoveAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}