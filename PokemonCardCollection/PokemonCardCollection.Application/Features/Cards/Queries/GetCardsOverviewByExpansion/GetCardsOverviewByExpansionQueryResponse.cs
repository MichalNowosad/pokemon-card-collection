using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion
{
    public class GetCardsOverviewByExpansionQueryResponse : ResponseBase
    {
        public GetCardsOverviewByExpansionQueryResponse(IEnumerable<CardOverviewDto> cards) : base()
        {
            Cards = cards;
        }

        public IEnumerable<CardOverviewDto> Cards { get; set; }
    }
}
