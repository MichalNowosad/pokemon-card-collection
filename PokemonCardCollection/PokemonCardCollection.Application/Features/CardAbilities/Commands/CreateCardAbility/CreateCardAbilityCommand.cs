using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility
{
    public class CreateCardAbilityCommand : IRequest<CreateCardAbilityCommandResponse>
    {
        public CreateCardAbilityCommand(CreateCardAbilityDto cardAbility)
        {
            CardAbility = cardAbility;
        }

        public CreateCardAbilityDto CardAbility { get; set; }
    }
}
