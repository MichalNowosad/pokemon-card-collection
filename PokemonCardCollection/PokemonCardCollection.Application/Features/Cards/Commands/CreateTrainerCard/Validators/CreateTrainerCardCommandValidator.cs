using FluentValidation;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard.Validators
{
    public class CreateTrainerCardCommandValidator : AbstractValidator<CreateTrainerCardCommand>
    {
        public CreateTrainerCardCommandValidator()
        {
            RuleFor(x => x.TrainerCard)
                .SetValidator(new CreateTrainerCardDtoValidator());
        }
    }
}
