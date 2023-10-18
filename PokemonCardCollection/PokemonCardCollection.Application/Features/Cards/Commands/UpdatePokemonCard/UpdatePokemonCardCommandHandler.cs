using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility.Validators;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System.Net;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard.Validators;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommandHandler : IRequestHandler<UpdatePokemonCardCommand, UpdatePokemonCardCommandResponse>
    {
        private readonly IPokemonCardRepository _pokemonCardRepository;
        private readonly ICardAttackRepository _cardAttackRepository;

        public UpdatePokemonCardCommandHandler(IPokemonCardRepository pokemonCardRepository,
            ICardAttackRepository cardAttackRepository)
        {
            _pokemonCardRepository = pokemonCardRepository ?? throw new ArgumentNullException(nameof(pokemonCardRepository));
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<UpdatePokemonCardCommandResponse> Handle(UpdatePokemonCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePokemonCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new UpdatePokemonCardCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var pokemonCardDto = request.PokemonCard;

            var pokemonCardToUpdate = await _pokemonCardRepository.GetAsync(pokemonCardDto.Id);

            if (pokemonCardToUpdate != null)
            {
                pokemonCardToUpdate.Name = pokemonCardDto.Name;
                pokemonCardToUpdate.Number = pokemonCardDto.Number;
                pokemonCardToUpdate.Rarity = pokemonCardDto.Rarity;
                pokemonCardToUpdate.ExpansionId = pokemonCardDto.ExpansionId;
                pokemonCardToUpdate.IllustratorId = pokemonCardDto.IllustratorId;
                pokemonCardToUpdate.HealthPoints = pokemonCardDto.HealthPoints;
                pokemonCardToUpdate.PokemonDescription = pokemonCardDto.PokemonDescription;
                pokemonCardToUpdate.EnergyType = pokemonCardDto.EnergyType;
                pokemonCardToUpdate.AbilityId = pokemonCardDto.AbilityId;
                pokemonCardToUpdate.Attacks = await _cardAttackRepository.GetByIds(pokemonCardDto.AttackIds).ToListAsync(cancellationToken: cancellationToken);

                await _pokemonCardRepository.SaveChangesAsync();
            }

            return new UpdatePokemonCardCommandResponse();
        }
    }
}
