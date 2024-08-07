using Microsoft.EntityFrameworkCore;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.Interfaces;
using SGE.Infrastructure.Common.Persistence;

namespace SGE.Infrastructure.Terms.Persistence;

public class TermsRepository(AppDbContext context) : ITermsRepository
{
    public async Task<IReadOnlyDictionary<string, IReadOnlyList<Term>>> GetTermsByCodesAsync(List<string> codes, CancellationToken cancellationToken)
    {
        var list = await context.Terms.Where(x => codes.Contains(x.Code)).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
        return list.ToDictionary(x => x.Code, x => x.Terms).AsReadOnly();
    }
}