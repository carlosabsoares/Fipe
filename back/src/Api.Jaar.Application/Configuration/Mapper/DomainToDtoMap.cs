using Api.Jaar.Domain.Responses;
using AutoMapper;

namespace Api.Jaar.Application.Configuration.Mapper
{
    public class DomainToDtoMap : Profile
    {
        public DomainToDtoMap()
        {
            CreateMap<BrasilApiResponse, ResponseCodFipeDto>()
                .ForMember(dst => dst.Fipe,
                    map => map.MapFrom(src => src.CodigoFipe))
                .ForMember(dst => dst.Valor,
                    map => map.MapFrom(src => src.Valor))
                .ForMember(dst => dst.Modelo,
                    map => map.MapFrom(src => src.Modelo))
                .ForMember(dst => dst.AnoModelo,
                    map => map.MapFrom(src => src.AnoModelo))
                .ForMember(dst => dst.Combustivel,
                    map => map.MapFrom(src => src.Combustivel))
                ;
        }
    }
}