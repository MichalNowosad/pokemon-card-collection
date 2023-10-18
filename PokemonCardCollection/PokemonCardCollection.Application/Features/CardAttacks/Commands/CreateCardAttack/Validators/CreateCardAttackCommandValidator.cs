using FluentValidation;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack.Validators
{
    public class CreateCardAttackCommandValidator : AbstractValidator<CreateCardAttackCommand>
    {
        public CreateCardAttackCommandValidator()
        {
            RuleFor(x => x.CardAttack)
                .SetValidator(new CreateCardAttackDtoValidator());
        }
    }
}
