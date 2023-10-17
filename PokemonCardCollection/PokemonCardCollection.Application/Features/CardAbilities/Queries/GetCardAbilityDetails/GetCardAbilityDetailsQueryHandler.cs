using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilityDetails
{
    public class GetCardAbilityDetailsQueryHandler : IRequestHandler<GetCardAbilityDetailsQuery, CardAbilityDetailsDto>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public GetCardAbilityDetailsQueryHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task<CardAbilityDetailsDto> Handle(GetCardAbilityDetailsQuery request, CancellationToken cancellationToken)
        {
            var cardAbility = await _cardAbilityRepository.GetAllAsync()
                .Select(a => new CardAbility
                {
                    Id = a.Id,
                    Description = a.Description,
                    Name = a.Name
                }).FirstOrDefaultAsync(a => a.Id == request.CardAttackId);

            return cardAbility;
        }
    }
}
