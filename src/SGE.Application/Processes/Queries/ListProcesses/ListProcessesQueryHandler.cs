using ErrorOr;
using MediatR;

using SGE.Domain.ProcessAggregate;
using SGE.Domain.ProcessAggregate.Interfaces;

namespace SGE.Application.Processes.Queries.ListProcesses;

public class ListProcessesQueryHandler(IProcessRepository repository) : IRequestHandler<ListProcessesQuery, ErrorOr<List<Process>>>
{
    public async Task<ErrorOr<List<Process>>> Handle(ListProcessesQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.ListAsync(cancellationToken);
        return result;
    }
}