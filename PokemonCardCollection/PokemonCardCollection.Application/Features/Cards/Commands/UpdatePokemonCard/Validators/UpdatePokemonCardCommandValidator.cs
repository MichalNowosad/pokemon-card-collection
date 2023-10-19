using FluentValidation;
using PokemonCardCollection.Application.Constants;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard.Validators
{
    public class UpdatePokemonCardCommandValidator : AbstractValidator<UpdatePokemonCardCommand>
    {
        public UpdatePokemonCardCommandValidator()
        {
            RuleFor(x => x.PokemonCard)
                .SetValidator(new UpdatePokemonCardDtoValidator());

            RuleFor(x => x.PokemonCardImage)
                .NotNull().WithMessage(ValidationConstants.FileNotUploadedErrorMessage);
        }
    }
}
