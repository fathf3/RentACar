using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.OurServiceCommands;
using RentACar.Application.Features.Mediator.Queries.OurServiceQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OurServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OurServiceList()
        {
            var values = await _mediator.Send(new GetOurServiceQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOurService(int id)
        {
            var value = await _mediator.Send(new GetOurServiceByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOurService(CreateOurServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hizmet başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOurService(int id)
        {
            await _mediator.Send(new RemoveOurServiceCommand(id));
            return Ok("Hizmet başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOurService(UpdateOurServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hizmet başarıyla güncellendi");
        }
    }
}
