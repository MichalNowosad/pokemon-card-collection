using PokemonCardCollection.Application.Models.File;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails
{
    public class ExpansionDetailsDto : FileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CardsAmount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
    }
}
