using AutoMapper;

namespace Api.Jaar.Application.Configuration.Mapper
{
    public class DomainToDtoMap : Profile
    {
        public DomainToDtoMap()
        {
            // Usar o .ReverseMap apenas quando necessário
            //CreateMap<Campanha, CampanhaDto>().ReverseMap();
        }
    }
}