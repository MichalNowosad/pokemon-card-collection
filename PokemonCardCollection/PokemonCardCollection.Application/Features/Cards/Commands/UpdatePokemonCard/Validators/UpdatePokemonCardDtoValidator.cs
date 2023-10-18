﻿using FluentValidation;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Domain.Constants;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard.Validators
{
    public class UpdatePokemonCardDtoValidator : AbstractValidator<UpdatePokemonCardDto>
    {
        public UpdatePokemonCardDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);

            RuleFor(x => x.ExpansionId)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

            RuleFor(x => x.IllustratorId)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage);

            RuleFor(p => p.PokemonDescription)
                .NotEmpty().WithMessage(ValidationConstants.ValueEmptyErrorMessage)
                .NotNull()
                .MaximumLength(CardConstants.NameMaxLength).WithMessage(ValidationConstants.MaxLengthErrorMessage);

        }
    }
}
