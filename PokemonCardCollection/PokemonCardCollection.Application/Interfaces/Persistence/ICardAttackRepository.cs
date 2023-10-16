using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Interfaces.Persistence
{
    public interface ICardAttackRepository : IRepositoryBase<CardAttack>
    {
        IQueryable<CardAttack> GetByIds(IEnumerable<Guid> cardIds);
    }
}
