using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttacksOverview
{
    public class GetCardAttacksOverviewQueryResponse : ResponseBase
    {
        public GetCardAttacksOverviewQueryResponse(IEnumerable<CardAttackOverviewDto> cardAttacks) : base()
        {
            CardAttacks = cardAttacks;
        }

        public IEnumerable<CardAttackOverviewDto> CardAttacks { get; set; }
    }
}
