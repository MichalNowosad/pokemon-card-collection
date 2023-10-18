using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack.Validators
{
    public class CreateCardAttackDtoValidator : AbstractValidator<CreateCardAttackDto>
    {
        public CreateCardAttackDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardAttackConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardAttackConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);
        }
    }
}
