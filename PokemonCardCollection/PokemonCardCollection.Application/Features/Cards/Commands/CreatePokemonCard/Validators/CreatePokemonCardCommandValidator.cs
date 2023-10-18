using FluentValidation;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard.Validators
{
    public class CreatePokemonCardCommandValidator : AbstractValidator<CreatePokemonCardCommand>
    {
        public CreatePokemonCardCommandValidator()
        {
            RuleFor(x => x.PokemonCard)
                .SetValidator(new CreatePokemonCardDtoValidator());
        }
    }
}
