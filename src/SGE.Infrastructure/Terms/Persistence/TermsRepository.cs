using Microsoft.EntityFrameworkCore;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.Interfaces;
using SGE.Infrastructure.Common.Persistence;

namespace SGE.Infrastructure.Terms.Persistence;

public class TermsRepository(AppDbContext context) : ITermsRepository
{
    public async Task<Dictionary<string, IReadOnlyList<Term>>> GetTermsByCodesAsync(List<string> codes, CancellationToken cancellationToken)
    {
        var results = await context.Terms.Include(x => x.Terms)
            .Where(x => codes.Contains(x.Code))
            .ToListAsync(cancellationToken: cancellationToken);
        return results.ToDictionary(x => x.Code, x => x.Terms);
    }
}