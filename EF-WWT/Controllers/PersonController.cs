using System.Threading.Tasks;
using EF_WWT.CQRS.Commands;
using EF_WWT.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EF_WWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactByNameAsync([FromQuery] GetContactByNameQuery query)
        {
             var result = await _mediator.Send(query);
             return Ok(result);
        }

        [HttpGet("Email")]
        public async Task<IActionResult> GetEmailByNameAsync([FromQuery] GetEmailAddressByNameQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Email")]
        public async Task<IActionResult> SaveEmailByNameAsync([FromBody] SavePersonEmailCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}