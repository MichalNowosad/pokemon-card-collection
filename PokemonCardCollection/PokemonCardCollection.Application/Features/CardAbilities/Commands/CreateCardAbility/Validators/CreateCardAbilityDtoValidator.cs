using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility.Validators
{
    public class CreateCardAbilityDtoValidator : AbstractValidator<CreateCardAbilityDto>
    {
        public CreateCardAbilityDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardAbilityConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardAbilityConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);
        }
    }
}
