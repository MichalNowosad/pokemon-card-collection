using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack
{
    public class CreateCardAttackCommand : IRequest<CreateCardAttackCommandResponse>
    {
        public CreateCardAttackDto CardAttack { get; set; } = new CreateCardAttackDto();
    }
}
