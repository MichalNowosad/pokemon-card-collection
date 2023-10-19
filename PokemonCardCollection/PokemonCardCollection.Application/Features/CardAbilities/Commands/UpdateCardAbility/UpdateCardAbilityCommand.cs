using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility
{
    public class UpdateCardAbilityCommand : IRequest<UpdateCardAbilityCommandResponse>
    {
        public UpdateCardAbilityCommand(UpdateCardAbilityDto cardAbility)
        {
            CardAbility = cardAbility;
        }

        public UpdateCardAbilityDto CardAbility { get; set; }
    }
}
