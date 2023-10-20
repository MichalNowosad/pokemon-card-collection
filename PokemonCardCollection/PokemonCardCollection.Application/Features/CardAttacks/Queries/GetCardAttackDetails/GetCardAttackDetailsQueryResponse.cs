using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails
{
    public class GetCardAttackDetailsQueryResponse : ResponseBase
    {
        public GetCardAttackDetailsQueryResponse(CardAttackDetailsDto cardAttack) : base()
        {
            CardAttack = cardAttack;
        }

        public CardAttackDetailsDto CardAttack { get; set; }
    }
}
