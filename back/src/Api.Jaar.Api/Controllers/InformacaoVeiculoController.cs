using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Jaar.Api.Controllers
{
    public class InformacaoVeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InformacaoVeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}