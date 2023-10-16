using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard
{
    public class CreatePokemonCardCommandHandler : IRequestHandler<CreatePokemonCardCommand, Guid>
    {
        private readonly IPokemonCardRepository _pokemonCardRepository;
        private readonly ICardAttackRepository _cardAttackRepository;

        public CreatePokemonCardCommandHandler(IPokemonCardRepository pokemonCardRepository,
            ICardAttackRepository cardAttackRepository)
        {
            _pokemonCardRepository = pokemonCardRepository ?? throw new ArgumentNullException(nameof(pokemonCardRepository));
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<Guid> Handle(CreatePokemonCardCommand request, CancellationToken cancellationToken)
        {
            var pokemonCardDto = request.PokemonCard;

            var cardAttacks = await _cardAttackRepository.GetByIds(pokemonCardDto.AttackIds).ToListAsync();

            var pokemonCard = new PokemonCard
            {
                Name = pokemonCardDto.Name,
                Number = pokemonCardDto.Number,
                Rarity = pokemonCardDto.Rarity,
                ExpansionId = pokemonCardDto.ExpansionId,
                IllustratorId = pokemonCardDto.IllustratorId,
                HealthPoints = pokemonCardDto.HealthPoints,
                PokemonDescription = pokemonCardDto.PokemonDescription,
                EnergyType = pokemonCardDto.EnergyType,
                AbilityId = pokemonCardDto.AbilityId,
                Attacks = cardAttacks
            };

            await _pokemonCardRepository.CreateAsync(pokemonCard);
            await _pokemonCardRepository.SaveChangesAsync();

            return pokemonCard.Id;
        }
    }
}
