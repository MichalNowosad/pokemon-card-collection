using FluentValidation;
using PokemonCardCollection.Application.Constants;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard.Validators
{
    public class CreatePokemonCardCommandValidator : AbstractValidator<CreatePokemonCardCommand>
    {
        public CreatePokemonCardCommandValidator()
        {
            RuleFor(x => x.PokemonCard)
                .SetValidator(new CreatePokemonCardDtoValidator());

            RuleFor(x => x.PokemonCardImage)
                .NotNull().WithMessage(ValidationConstants.FileNotUploadedErrorMessage);
        }
    }
}
