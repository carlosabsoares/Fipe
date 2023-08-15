using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Api.Jaar.Api.DependencyMap
{
    public static class ServiceDependencyMap
    {
        public static void ServiceMap(this IServiceCollection services, IConfiguration configuration)
        {
            // ----- SERVICES --------
            services.AddHttpClient();

            // Biblioteca para manipulação do JWT
            //services.AddScoped<ICommandHandler<PostUserValidateCommand>>(sp =>
            //{
            //    return new AgendaRepository(
            //        configuration.GetValue<string>("ConnectionStrings:DefaultConnection")
            //    );
            //});
        }
    }
}