using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommandHandler : IRequestHandler<UpdatePokemonCardCommand>
    {
        private readonly IPokemonCardRepository _pokemonCardRepository;
        private readonly ICardAttackRepository _cardAttackRepository;

        public UpdatePokemonCardCommandHandler(IPokemonCardRepository pokemonCardRepository,
            ICardAttackRepository cardAttackRepository)
        {
            _pokemonCardRepository = pokemonCardRepository ?? throw new ArgumentNullException(nameof(pokemonCardRepository));
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task Handle(UpdatePokemonCardCommand request, CancellationToken cancellationToken)
        {
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
                pokemonCardToUpdate.Attacks = await _cardAttackRepository.GetByIds(pokemonCardDto.AttackIds).ToListAsync();

                await _pokemonCardRepository.SaveChangesAsync();
            }
        }
    }
}
