namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionDto
    {
        public string Name { get; set; } = string.Empty;
        public int CardsAmount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
    }
}
