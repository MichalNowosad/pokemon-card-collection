using FluentValidation;
using PokemonCardCollection.Application.Constants;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion.Validators
{
    public class UpdateExpansionCommandValidator : AbstractValidator<UpdateExpansionCommand>
    {
        public UpdateExpansionCommandValidator()
        {
            RuleFor(x => x.Expansion)
                .SetValidator(new UpdateExpansionDtoValidator());

            RuleFor(x => x.ExpansionImage)
                .NotNull().WithMessage(ValidationConstants.FileNotUploadedErrorMessage);
        }
    }
}
