using FluentValidation;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility.Validators
{
    public class CreateCardAbilityCommandValidator : AbstractValidator<CreateCardAbilityCommand>
    {
        public CreateCardAbilityCommandValidator()
        {
            RuleFor(x => x.CardAbility)
                .SetValidator(new CreateCardAbilityDtoValidator());
        }
    }
}
