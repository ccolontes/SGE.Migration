namespace SGE.Domain.TermAggregate.Interfaces;

public interface ITermsRepository
{
    Task<Dictionary<string, IReadOnlyList<Term>>> GetTermsByCodesAsync(List<string> codes, CancellationToken cancellationToken);
}
