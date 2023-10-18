using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion.Validators
{
    public class CreateExpansionDtoValidator : AbstractValidator<CreateExpansionDto>
    {
        public CreateExpansionDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(ExpansionConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);

            RuleFor(p => p.Abbreviation)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(ExpansionConstants.AbbreviationMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);
        }
    }
}
