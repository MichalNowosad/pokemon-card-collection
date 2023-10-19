using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack
{
    public class UpdateCardAttackCommand : IRequest<UpdateCardAttackCommandResponse>
    {
        public UpdateCardAttackCommand(UpdateCardAttackDto cardAttack)
        {
            CardAttack = cardAttack;
        }

        public UpdateCardAttackDto CardAttack { get; set; }
    }
}
