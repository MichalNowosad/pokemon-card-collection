using PokemonCardCollection.Domain.Common;

namespace PokemonCardCollection.Domain.Entities
{
    public class CardAbility : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
