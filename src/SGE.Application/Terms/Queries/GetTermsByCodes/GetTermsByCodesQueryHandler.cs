using ErrorOr;

using MediatR;

using SGE.Domain.TermAggregate;
using SGE.Domain.TermAggregate.Interfaces;

namespace SGE.Application.Terms.Queries.GetTermsByCodes;

public class GetTermsByCodesQueryHandler(ITermsRepository repository) : IRequestHandler<GetTermsByCodesQuery, ErrorOr<Dictionary<string, IReadOnlyList<Term>>>>
{
    public async Task<ErrorOr<Dictionary<string, IReadOnlyList<Term>>>> Handle(GetTermsByCodesQuery request, CancellationToken cancellationToken)
    {
       var result = await repository.GetTermsByCodesAsync(request.Codes, cancellationToken);
       return result;
    }
}