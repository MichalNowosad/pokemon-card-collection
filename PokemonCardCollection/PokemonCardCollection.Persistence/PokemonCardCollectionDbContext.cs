using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence
{
    public class PokemonCardCollectionDbContext : DbContext
    {
        public PokemonCardCollectionDbContext(DbContextOptions<PokemonCardCollectionDbContext> options) : base(options)
        {

        }

        public DbSet<CardAbility> CardAbilities { get; set; }
        public DbSet<CardAttack> CardAttacks { get; set; }
        public DbSet<Expansion> Expansions { get; set; }
        public DbSet<Illustrator> Illustrators { get; set; }
        public DbSet<PokemonCard> PokemonCards { get; set; }
        public DbSet<TrainerCard> TrainerCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokemonCardCollectionDbContext).Assembly);
        }
    }
}
