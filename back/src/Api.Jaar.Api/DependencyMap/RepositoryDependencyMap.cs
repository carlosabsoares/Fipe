using Api.Jaar.Domain.Repositories;
using Api.Jaar.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Jaar.Api.DependencyMap
{
    public static class RepositoryDependencyMap
    {
        public static void RepositoryMap(this IServiceCollection services)
        {
            services.AddScoped<ICudRepository, CudRepository>();
            services.AddScoped<IInfoVeiculoRepository, InfoVeiculoRepository>();
        }
    }
}