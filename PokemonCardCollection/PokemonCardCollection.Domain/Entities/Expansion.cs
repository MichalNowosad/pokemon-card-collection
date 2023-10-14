using PokemonCardCollection.Domain.Common;

namespace PokemonCardCollection.Domain.Entities
{
    public class Expansion : EntityWithFile
    {
        public string Name { get; set; } = string.Empty;
        public int CardsNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
    }
}
