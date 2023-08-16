using Api.Jaar.Application.Commands.AppFipe;
using Api.Jaar.Domain.Entities;
using AutoMapper;

namespace Api.Jaar.Api.DependencyMap
{
    public class DomainToDtoMap : Profile
    {
        public DomainToDtoMap()
        {
            CreateMap<PostIncluiPlacaCommand, InfoVeiculoEntity>()
                .ForMember(dest=> dest.AnoModelo, act=> act.MapFrom(src => src.AnoModelo))
                .ForMember(dest => dest.CodigoFipe, act => act.MapFrom(src => src.CodigoFipe))
                .ForMember(dest => dest.Placa, act => act.MapFrom(src => src.Placa))
                ;
        }
    }
}