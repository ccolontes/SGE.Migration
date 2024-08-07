namespace SGE.Domain.TermAggregate.Interfaces;

public interface ITermsRepository
{
    Task<IReadOnlyDictionary<string, IReadOnlyList<Term>>> GetTermsByCodesAsync(List<string> codes, CancellationToken cancellationToken);
}
