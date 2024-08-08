using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using SGE.Application.Terms.Queries.GetTermsByCodes;
using SGE.Contracts.Terms;

namespace SGE.Api.Controllers;

[Route("api/[controller]")]
public class TermController(ISender mediator, IMapper mapper) : ApiController
{
   [HttpPost("terms_by_codes", Name = "terms_by_codes")]
   public async Task<IActionResult> GetTermsByCodes(GetTermsRequest request)
   {
       var query = request.Adapt<GetTermsByCodesQuery>();
       var response = await mediator.Send(query);
       return response.Match(
           terms => Ok(terms.ToDictionary(
               x => x.Key,
               x => x.Value.Select(mapper.Map<TermResponse>).ToList())),
           err => Problem(err));
   }
}