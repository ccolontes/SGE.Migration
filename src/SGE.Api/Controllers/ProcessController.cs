using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SGE.Application.Processes.Queries.ListProcesses;
using SGE.Contracts.Processes;

namespace SGE.Api.Controllers;

[Route("api/[controller]")]
public class ProcessController(ISender mediator, IMapper mapper) : ApiController
{
    [HttpGet("processes")]
    public async Task<IActionResult> ListProcesses()
    {
        var query = new ListProcessesQuery();
        var response = await mediator.Send(query);

        return response.Match(
            processes => Ok(processes.ConvertAll(mapper.Map<ProcessResponse>)),
            err => Problem(err));
    }
}