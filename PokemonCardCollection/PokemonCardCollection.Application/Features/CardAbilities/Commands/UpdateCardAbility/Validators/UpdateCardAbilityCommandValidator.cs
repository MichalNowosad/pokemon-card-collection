using FluentValidation;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility.Validators
{
    public class UpdateCardAbilityCommandValidator : AbstractValidator<UpdateCardAbilityCommand>
    {
        public UpdateCardAbilityCommandValidator()
        {
            RuleFor(x => x.CardAbility)
                .SetValidator(new UpdateCardAbilityDtoValidator());
        }
    }
}
