using PokemonCardCollection.Domain.Common;

namespace PokemonCardCollection.Domain.Entities
{
    public class CardAttack : BaseEntity
    {
        public CardAttack()
        {
            PokemonCards = new HashSet<PokemonCard>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Power { get; set; }
        public ICollection<PokemonCard> PokemonCards { get; set; }
    }
}
