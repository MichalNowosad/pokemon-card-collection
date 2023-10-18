using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Persistence.Respositories;

namespace PokemonCardCollection.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PokemonCardCollectionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PokemonCardCollectionConnectionString")));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<ICardAbilityRepository, CardAbilityRepository>();
            services.AddScoped<ICardAttackRepository, CardAttackRepository>();
            services.AddScoped<IExpansionRepository, ExpansionRepository>();
            services.AddScoped<IPokemonCardRepository, PokemonCardRepository>();
            services.AddScoped<ITrainerCardRepository, TrainerCardRepository>();

            return services;
        }
    }
}
