using FluentValidation;
using PokemonCardCollection.Application.Constants;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion.Validators
{
    public class CreateExpansionCommandValidator : AbstractValidator<CreateExpansionCommand>
    {
        public CreateExpansionCommandValidator()
        {
            RuleFor(x => x.Expansion)
                .SetValidator(new CreateExpansionDtoValidator());

            RuleFor(x => x.ExpansionImage)
                .NotNull().WithMessage(ValidationConstants.FileNotUploadedErrorMessage);
        }
    }
}
