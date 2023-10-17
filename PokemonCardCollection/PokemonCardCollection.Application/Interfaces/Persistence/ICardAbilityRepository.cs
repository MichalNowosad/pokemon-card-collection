using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Interfaces.Persistence
{
    public interface ICardAbilityRepository : IRepositoryBase<CardAbility>
    {
        IQueryable<CardAbility> GetByIds(IEnumerable<Guid> cardIds);
    }
}
