using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails
{
    public class GetPokemonCardDetailsQueryHandler : IRequestHandler<GetPokemonCardDetailsQuery, PokemonCardDetailsDto>
    {
        private readonly IPokemonCardRepository _pokemonCardRepository;

        public GetPokemonCardDetailsQueryHandler(IPokemonCardRepository pokemonCardRepository)
        {
            _pokemonCardRepository = pokemonCardRepository ?? throw new ArgumentNullException(nameof(pokemonCardRepository));
        }

        public async Task<PokemonCardDetailsDto> Handle(GetPokemonCardDetailsQuery request, CancellationToken cancellationToken)
        {
            var allPokemonCards = _pokemonCardRepository.GetAllAsync();

            var pokemonCard = await allPokemonCards.Select(c => new PokemonCardDetailsDto
            {
                Id = c.Id,
                Name = c.Name,
                Number = c.Number,
                HealthPoints = c.HealthPoints,
                Description = c.PokemonDescription,
                EnergyType = c.EnergyType,
                Rarity = c.Rarity,
                ExpansionName = c.Expansion != null ? c.Expansion.Name : string.Empty,
                IllustratorName = c.Illustrator != null ? c.Illustrator.Name : string.Empty,
                Ability = c.Ability != null ? new PokemonCardAbilityDto
                {
                    Name = c.Ability.Name,
                    Description = c.Ability.Description
                } : null,
                Attacks = c.Attacks != null ? c.Attacks.Select(a => new PokemonCardAttackDto
                {
                    Name = a.Name,
                    Description = a.Description,
                    Power = a.Power
                }) : null
            }).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

            return pokemonCard;
        }
    }
}
