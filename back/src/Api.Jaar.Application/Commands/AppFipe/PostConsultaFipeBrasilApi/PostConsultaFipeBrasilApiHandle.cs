using Api.Jaar.Application.Configuration.Commands;
using Api.Jaar.Application.Configuration.Events;
using Api.Jaar.Domain.Responses;
using Api.Jaar.Domain.Servicos;
using AutoMapper;
using DocumentFormat.OpenXml.InkML;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Jaar.Application.Commands.AppFipe
{
    public class PostConsultaFipeBrasilApiHandle : Notifiable, ICommandHandler<PostConsultaFipeBrasilApiCommand>
    {
        private readonly IServiceBrasilApi _service;
        private readonly IMapper _mapper;

        public PostConsultaFipeBrasilApiHandle(IServiceBrasilApi service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEvent> Handle(PostConsultaFipeBrasilApiCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            try
            {
                var _responseService = await _service.BrasilApiPreco(request.CodigoFipe, request.AnoModelo);

                var _result = _mapper.Map<ResponseCodFipeDto>(_responseService);


                return new ResultEvent(true, _result == null ? null : _result);
            }
            catch (System.Exception ex)
            {
                return new ResultEvent(false, $"Erro {ex.Message}");
            }
        }
    }
}