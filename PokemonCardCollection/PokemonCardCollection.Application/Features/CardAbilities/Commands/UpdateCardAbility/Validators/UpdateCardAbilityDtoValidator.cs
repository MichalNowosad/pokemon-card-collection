using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility.Validators
{
    public class UpdateCardAbilityDtoValidator : AbstractValidator<UpdateCardAbilityDto>
    {
        public UpdateCardAbilityDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

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
