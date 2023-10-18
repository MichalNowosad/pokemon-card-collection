using PokemonCardCollection.Domain.Common;

namespace PokemonCardCollection.Domain.Entities
{
    public class Expansion : EntityWithFile
    {
        public Expansion()
        {
            PokemonCards = new HashSet<PokemonCard>();
            TrainerCards = new HashSet<TrainerCard>();
        }

        public string Name { get; set; } = string.Empty;
        public int CardsAmount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
        public ICollection<PokemonCard> PokemonCards { get; set; }
        public ICollection<TrainerCard> TrainerCards { get; set; }
    }
}
