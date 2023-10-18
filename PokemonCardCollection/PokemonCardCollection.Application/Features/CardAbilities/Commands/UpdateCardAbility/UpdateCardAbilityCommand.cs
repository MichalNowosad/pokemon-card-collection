using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility
{
    public class UpdateCardAbilityCommand : IRequest<UpdateCardAbilityCommandResponse>
    {
        public UpdateCardAbilityDto CardAbility { get; set; } = new UpdateCardAbilityDto();
    }
}
