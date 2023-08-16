using Api.Jaar.Application.Configuration.Commands;
using Api.Jaar.Application.Configuration.Events;
using Api.Jaar.Domain.Entities;
using Api.Jaar.Domain.Repositories;
using Api.Jaar.Domain.Servicos;
using AutoMapper;
using Flunt.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Jaar.Application.Commands.AppFipe
{
    public class PostIncluiPlacaHandle : Notifiable, ICommandHandler<PostIncluiPlacaCommand>
    {
        private readonly IServiceBrasilApi _service;
        private readonly IInfoVeiculoRepository _repository;
        private readonly IMapper _mapper;

        public PostIncluiPlacaHandle(IServiceBrasilApi service, 
                                     IInfoVeiculoRepository repository,
                                     IMapper mapper)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEvent> Handle(PostIncluiPlacaCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new ResultEvent(false, request.Notifications);

            try
            {
                var _repoInfoVeiculo = await _repository.FindByPlaca(request.Placa);

                if(_repoInfoVeiculo != null)
                    return new ResultEvent(true, $"Placa já cadastrada");

                var _responseService = await _service.BrasilApiPreco(request.CodigoFipe,
                                                                     request.AnoModelo);

                if (_responseService == null)
                    return new ResultEvent(true, $"Código não localizado");

                var entity = new InfoVeiculoEntity() 
                { 
                    AnoModelo = _responseService.AnoModelo,
                    CodigoFipe = _responseService.CodigoFipe,
                    Placa = request.Placa
                };

                var result = await _repository.AddAsync(entity);

                return new ResultEvent(true, result ? result : null);
            }
            catch (System.Exception ex)
            {
                return new ResultEvent(false, $"Erro {ex.Message}");
            }
        }
    }
}