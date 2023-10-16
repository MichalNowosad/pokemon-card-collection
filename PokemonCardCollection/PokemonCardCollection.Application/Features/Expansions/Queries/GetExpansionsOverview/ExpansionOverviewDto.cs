namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionsOverview
{
    public class ExpansionOverviewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
    }
}
