using FluentValidation;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack.Validators
{
    public class UpdateCardAttackCommandValidator : AbstractValidator<UpdateCardAttackCommand>
    {
        public UpdateCardAttackCommandValidator()
        {
            RuleFor(x => x.CardAttack)
                .SetValidator(new UpdateCardAttackDtoValidator());
        }
    }
}
