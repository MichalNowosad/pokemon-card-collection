using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack
{
    public class CreateCardAttackCommand : IRequest<Guid>
    {
        public CreateCardAttackDto CardAttack { get; set; }
    }
}
