using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using SGE.Application.Terms.Queries.ListTerms;
using SGE.Contracts.Terms;

namespace SGE.Api.Controllers;

[Route("api/[controller]")]
public class TermController(ISender mediator) : ApiController
{
   [HttpPost("GetTerms", Name = "GetTerms")]
   public async Task<IActionResult> GetTerms(GetTermsRequest request)
   {
       var query = request.Adapt<ListTermsQuery>();
       var response = await mediator.Send(query);
       return response.Match(
           terms => Ok(terms.ConvertAll(term => term.Adapt<TermResponse>())),
           err => Problem(err));
   }
}