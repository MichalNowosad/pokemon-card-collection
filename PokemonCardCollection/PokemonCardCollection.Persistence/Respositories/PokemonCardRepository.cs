using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Respositories
{
    public class PokemonCardRepository : RepositoryBase<PokemonCard>, IPokemonCardRepository
    {
        private readonly DbSet<PokemonCard> _pokemonCards;

        public PokemonCardRepository(PokemonCardCollectionDbContext dbContext) : base(dbContext)
        {
            _pokemonCards = dbContext.Set<PokemonCard>();
        }

        public IQueryable<PokemonCard> GetByExpansionId(Guid expansionId)
        {
            return _pokemonCards.Where(c => c.ExpansionId == expansionId);
        }
    }
}
