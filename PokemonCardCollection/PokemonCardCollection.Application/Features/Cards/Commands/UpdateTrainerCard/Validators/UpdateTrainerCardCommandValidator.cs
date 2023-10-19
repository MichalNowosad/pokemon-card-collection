using FluentValidation;
using PokemonCardCollection.Application.Constants;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard.Validators
{
    public class UpdateTrainerCardCommandValidator : AbstractValidator<UpdateTrainerCardCommand>
    {
        public UpdateTrainerCardCommandValidator()
        {
            RuleFor(x => x.TrainerCard)
                .SetValidator(new UpdateTrainerCardDtoValidator());

            RuleFor(x => x.TrainerCardImage)
                .NotNull().WithMessage(ValidationConstants.FileNotUploadedErrorMessage);
        }
    }
}
