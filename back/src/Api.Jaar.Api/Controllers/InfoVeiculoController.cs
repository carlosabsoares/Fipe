using Api.Jaar.Application.Commands.AppFipe;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Jaar.Api.Controllers
{
    public class InfoVeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InfoVeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ConsultaFipeBrasilApi")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> PostConsultaFipeBrasilApi(
        [FromBody] PostConsultaFipeBrasilApiCommand command
        )
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return new BadRequestObjectResult(result.Data);
            }
            return new OkObjectResult(result.Data);
        }

        [HttpPost("CadastraPlaca")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> PostIncluiPlaca(
        [FromBody] PostIncluiPlacaCommand command
        )
        {

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return new BadRequestObjectResult(result.Data);
            }
            return new OkObjectResult(result.Data);
        }

        [HttpGet("ConsultaPlaca")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> GetConsultaPlaca(
        [FromQuery] GetConsultarPlacaQuery query
        )
        {
            var result = await _mediator.Send(query);

            if (!result.Success)
            {
                return new BadRequestObjectResult(result.Data);
            }
            return new OkObjectResult(result.Data);
        }
    }
}