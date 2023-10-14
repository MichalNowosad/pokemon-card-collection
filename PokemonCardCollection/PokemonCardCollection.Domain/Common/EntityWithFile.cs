namespace PokemonCardCollection.Domain.Common
{
    public class EntityWithFile : BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string DisplayFileName { get; set; } = string.Empty;
    }
}
