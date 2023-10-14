using PokemonCardCollection.Domain.Common;

namespace PokemonCardCollection.Domain.Entities
{
    public class Illustrator : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
