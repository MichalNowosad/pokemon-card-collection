using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility
{
    public class CreateCardAbilityCommand : IRequest<CreateCardAbilityCommandResponse>
    {
        public CreateCardAbilityDto CardAbility { get; set; } = new CreateCardAbilityDto();
    }
}
