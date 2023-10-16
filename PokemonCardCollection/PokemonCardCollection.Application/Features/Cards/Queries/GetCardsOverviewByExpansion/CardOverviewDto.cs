using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion
{
    public class CardOverviewDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
