using PokemonCardCollection.Domain.Common;

namespace PokemonCardCollection.Domain.Entities
{
    public class Illustrator : BaseEntity
    {
        public Illustrator()
        {
            PokemonCards = new HashSet<PokemonCard>();
            TrainerCards = new HashSet<TrainerCard>();
        }

        public string Name { get; set; } = string.Empty;
        public ICollection<PokemonCard> PokemonCards { get; set; }
        public ICollection<TrainerCard> TrainerCards { get; set; }
    }
}
