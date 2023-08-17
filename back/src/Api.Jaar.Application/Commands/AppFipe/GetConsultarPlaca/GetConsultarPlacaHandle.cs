using Api.Jaar.Application.Configuration.Events;
using Api.Jaar.Application.Configuration.Queries;
using Api.Jaar.Domain.Repositories;
using Api.Jaar.Domain.Servicos;
using AutoMapper;
using Flunt.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Jaar.Application.Commands.AppFipe
{
    public class GetConsultarPlacaHandle : Notifiable, IQueryHandler<GetConsultarPlacaQuery>
    {
        private readonly IServiceBrasilApi _service;
        private readonly IInfoVeiculoRepository _repository;
        private readonly IMapper _mapper;

        public GetConsultarPlacaHandle(IServiceBrasilApi service,
                                       IInfoVeiculoRepository repository,
                                       IMapper mapper)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEvent> Handle(GetConsultarPlacaQuery request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            try
            {
                var _repoInfo = await _repository.FindByPlaca(request.Placa);

                if (_repoInfo == null)
                    return new ResultEvent(false, "Placa não localizada ou não cadastrada");

                var _codigoFipe = Convert.ToInt32(_repoInfo.CodigoFipe.Replace("-", ""));

                var _responseService = await _service.BrasilApiPreco(_codigoFipe, _repoInfo.AnoModelo);

                return new ResultEvent(true, _responseService == null ? null : _responseService);
            }
            catch (System.Exception ex)
            {
                return new ResultEvent(false, $"Erro {ex.Message}");
            }
        }
    }
}