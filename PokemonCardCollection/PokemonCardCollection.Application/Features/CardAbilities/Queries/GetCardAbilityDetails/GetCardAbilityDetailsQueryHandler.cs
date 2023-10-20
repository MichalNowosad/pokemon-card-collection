using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilityDetails
{
    public class GetCardAbilityDetailsQueryHandler : IRequestHandler<GetCardAbilityDetailsQuery, GetCardAbilityDetailsQueryResponse>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public GetCardAbilityDetailsQueryHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task<GetCardAbilityDetailsQueryResponse> Handle(GetCardAbilityDetailsQuery request, CancellationToken cancellationToken)
        {
            var cardAbility = await _cardAbilityRepository.GetAllAsync()
                .Select(a => new CardAbilityDetailsDto
                {
                    Id = a.Id,
                    Description = a.Description,
                    Name = a.Name
                }).FirstOrDefaultAsync(a => a.Id == request.Id);

            return new GetCardAbilityDetailsQueryResponse(cardAbility);
        }
    }
}
