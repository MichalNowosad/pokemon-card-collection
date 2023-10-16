using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack
{
    public class UpdateCardAttackCommand : IRequest
    {
        public UpdateCardAttackDto? CardAttack { get; set; }
    }
}
