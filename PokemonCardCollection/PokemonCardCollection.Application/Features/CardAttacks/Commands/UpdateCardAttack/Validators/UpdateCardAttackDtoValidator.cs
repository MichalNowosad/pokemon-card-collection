using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack.Validators
{
    public class UpdateCardAttackDtoValidator : AbstractValidator<UpdateCardAttackDto>
    {
        public UpdateCardAttackDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

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
