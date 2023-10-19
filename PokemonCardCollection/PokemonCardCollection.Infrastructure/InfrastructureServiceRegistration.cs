using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Infrastructure.Files;

namespace PokemonCardCollection.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
