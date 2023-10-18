using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard.Validators
{
    public class CreatePokemonCardDtoValidator : AbstractValidator<CreatePokemonCardDto>
    {
        public CreatePokemonCardDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);

            RuleFor(x => x.ExpansionId)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

            RuleFor(x => x.IllustratorId)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

            RuleFor(p => p.PokemonDescription)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);
        }
    }
}
