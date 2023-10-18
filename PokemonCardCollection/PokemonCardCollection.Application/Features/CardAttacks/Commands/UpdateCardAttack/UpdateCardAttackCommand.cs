using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack
{
    public class UpdateCardAttackCommand : IRequest<UpdateCardAttackCommandResponse>
    {
        public UpdateCardAttackDto CardAttack { get; set; } = new UpdateCardAttackDto();
    }
}
