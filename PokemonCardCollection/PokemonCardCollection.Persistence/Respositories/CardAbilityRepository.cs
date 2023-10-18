using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Respositories
{
    public class CardAbilityRepository : RepositoryBase<CardAbility>, ICardAbilityRepository
    {
        private readonly DbSet<CardAbility> _cardAbilities;

        public CardAbilityRepository(PokemonCardCollectionDbContext dbContext) : base(dbContext)
        {
            _cardAbilities = dbContext.Set<CardAbility>();
        }

        public IQueryable<CardAbility> GetByIds(IEnumerable<Guid> cardIds)
        {
            return _cardAbilities.Where(a => cardIds.Contains(a.Id));
        }
    }
}
