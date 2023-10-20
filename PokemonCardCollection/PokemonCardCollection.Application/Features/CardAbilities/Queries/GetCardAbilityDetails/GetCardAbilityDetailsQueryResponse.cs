using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilityDetails
{
    public class GetCardAbilityDetailsQueryResponse : ResponseBase
    {
        public GetCardAbilityDetailsQueryResponse(CardAbilityDetailsDto cardAbility) : base()
        {
            CardAbility = cardAbility;
        }

        public GetCardAbilityDetailsQueryResponse(CardAbilityDetailsDto cardAbility, HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
            CardAbility = cardAbility;
        }

        public CardAbilityDetailsDto CardAbility { get; set; }
    }
}
