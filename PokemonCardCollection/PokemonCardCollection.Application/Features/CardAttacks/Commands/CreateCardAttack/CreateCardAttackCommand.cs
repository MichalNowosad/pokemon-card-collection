using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack
{
    public class CreateCardAttackCommand : IRequest<CreateCardAttackCommandResponse>
    {
        public CreateCardAttackCommand(CreateCardAttackDto cardAttack)
        {
            CardAttack = cardAttack;
        }

        public CreateCardAttackDto CardAttack { get; set; }
    }
}
