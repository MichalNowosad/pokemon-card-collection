using PokemonCardCollection.Domain.Common;
using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Domain.Entities
{
    public class Card : EntityWithFile
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public CardRarity Rarity { get; set; }
        public CardType CardType { get; set; }
        public Guid ExpansionId { get; set; }
        public Expansion? Expansion { get; set; }
        public Guid IllustratorId { get; set; }
        public Illustrator? Illustrator { get; set; }
    }
}
