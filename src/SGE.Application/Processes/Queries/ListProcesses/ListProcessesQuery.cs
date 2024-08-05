using ErrorOr;

using MediatR;

using SGE.Domain.ProcessAggregate;

namespace SGE.Application.Processes.Queries.ListProcesses;

public record ListProcessesQuery() : IRequest<ErrorOr<List<Process>>>;