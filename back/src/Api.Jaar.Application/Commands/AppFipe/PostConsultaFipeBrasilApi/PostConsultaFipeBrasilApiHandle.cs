using Api.Jaar.Application.Configuration.Commands;
using Api.Jaar.Application.Configuration.Events;
using Api.Jaar.Domain.Repositories;
using Api.Jaar.Domain.Servicos;
using Flunt.Notifications;
using Flunt.Validations;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Jaar.Application.Commands.AppFipe
{
    public class PostConsultaFipeBrasilApiHandle : Notifiable, ICommandHandler<PostConsultaFipeBrasilApiCommand>
    {

        private readonly IServiceBrasilApi _service;

        public PostConsultaFipeBrasilApiHandle(IServiceBrasilApi service)
        {
            _service = service;
        }

        public async Task<IEvent> Handle(PostConsultaFipeBrasilApiCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            try
            {
                var _responseService = await _service.BrasilApiPreco(request.CodigoFipe, request.AnoModelo);

                return new ResultEvent(true, _responseService == null ? null : _responseService);
            }
            catch (System.Exception ex)
            {
                return new ResultEvent(false, $"Erro {ex.Message}");
            }


        }
    }
}
