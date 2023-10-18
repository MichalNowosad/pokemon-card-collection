using FluentValidation;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion.Validators
{
    public class CreateExpansionCommandValidator : AbstractValidator<CreateExpansionCommand>
    {
        public CreateExpansionCommandValidator()
        {
            RuleFor(x => x.Expansion)
                .SetValidator(new CreateExpansionDtoValidator());
        }
    }
}
