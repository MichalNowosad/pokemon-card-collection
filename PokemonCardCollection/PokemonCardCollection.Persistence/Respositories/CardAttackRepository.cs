using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Respositories
{
    public class CardAttackRepository : RepositoryBase<CardAttack>, ICardAttackRepository
    {
        private readonly DbSet<CardAttack> _cardAttacks;

        public CardAttackRepository(PokemonCardCollectionDbContext dbContext) : base(dbContext)
        {
            _cardAttacks = dbContext.Set<CardAttack>();
        }

        public IQueryable<CardAttack> GetByIds(IEnumerable<Guid> cardIds)
        {
            return _cardAttacks.Where(a => cardIds.Contains(a.Id));
        }
    }
}
