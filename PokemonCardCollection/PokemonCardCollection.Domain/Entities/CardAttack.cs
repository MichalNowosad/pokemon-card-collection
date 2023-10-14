using PokemonCardCollection.Domain.Common;

namespace PokemonCardCollection.Domain.Entities
{
    public class CardAttack : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Power { get; set; }
    }
}
