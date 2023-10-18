using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion.Validators
{
    public class UpdateExpansionDtoValidator : AbstractValidator<UpdateExpansionDto>
    {
        public UpdateExpansionDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

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
