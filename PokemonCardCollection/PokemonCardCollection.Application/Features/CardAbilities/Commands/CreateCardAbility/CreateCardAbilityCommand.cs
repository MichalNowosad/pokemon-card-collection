using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility
{
    public class CreateCardAbilityCommand : IRequest<Guid>
    {
        public CreateCardAbilityDto? CardAbility { get; set; }
    }
}
