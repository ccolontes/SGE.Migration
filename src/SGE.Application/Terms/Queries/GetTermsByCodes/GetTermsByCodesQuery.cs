using ErrorOr;

using MediatR;

using SGE.Domain.TermAggregate;

namespace SGE.Application.Terms.Queries.GetTermsByCodes;

public record GetTermsByCodesQuery(List<string> Codes) : IRequest<ErrorOr<Dictionary<string, IReadOnlyList<Term>>>>;