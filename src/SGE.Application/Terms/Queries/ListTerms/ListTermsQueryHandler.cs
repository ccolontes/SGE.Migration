using ErrorOr;

using MediatR;

using SGE.Domain.TermAggregate;

namespace SGE.Application.Terms.Queries.ListTerms;

public class ListTermsQueryHandler : IRequestHandler<ListTermsQuery, ErrorOr<List<Term>>>
{
    public Task<ErrorOr<List<Term>>> Handle(ListTermsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}