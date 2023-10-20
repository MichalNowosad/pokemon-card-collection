using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilitiesOverview
{
    public class GetCardAbilitiesOverviewQueryResponse : ResponseBase
    {
        public GetCardAbilitiesOverviewQueryResponse(IEnumerable<CardAbilityOverviewDto> cardAbilities) : base()
        {
            CardAbilities = cardAbilities;
        }

        public IEnumerable<CardAbilityOverviewDto> CardAbilities { get; set; }
    }
}
