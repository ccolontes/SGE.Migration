using ErrorOr;
using MediatR;

using SGE.Domain.TermAggregate;

namespace SGE.Application.Terms.Queries.ListTerms;

public record ListTermsQuery(ICollection<string> Codes) : IRequest<ErrorOr<List<Term>>>;