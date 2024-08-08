using Microsoft.EntityFrameworkCore;

using SGE.Domain.ProcessAggregate;
using SGE.Domain.ProcessAggregate.Interfaces;
using SGE.Infrastructure.Common.Persistence;

namespace SGE.Infrastructure.Processes.Persistence;

public class ProcessRepository(AppDbContext context) : IProcessRepository
{
    public async Task<List<Process>> ListAsync(CancellationToken cancellationToken)
    {
        return await context.Processes.ToListAsync(cancellationToken: cancellationToken);
    }
}



