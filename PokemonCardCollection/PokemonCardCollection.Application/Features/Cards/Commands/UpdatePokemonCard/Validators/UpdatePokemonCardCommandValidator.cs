using FluentValidation;
using PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard.Validators
{
    public class UpdatePokemonCardCommandValidator : AbstractValidator<UpdatePokemonCardCommand>
    {
        public UpdatePokemonCardCommandValidator()
        {
            RuleFor(x => x.PokemonCard)
                .SetValidator(new UpdatePokemonCardDtoValidator());
        }
    }
}
