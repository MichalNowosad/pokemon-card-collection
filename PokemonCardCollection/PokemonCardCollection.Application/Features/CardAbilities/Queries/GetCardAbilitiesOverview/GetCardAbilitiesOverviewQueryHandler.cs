using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilitiesOverview
{
    public class GetCardAbilitiesOverviewQueryHandler : IRequestHandler<GetCardAbilitiesOverviewQuery, GetCardAbilitiesOverviewQueryResponse>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public GetCardAbilitiesOverviewQueryHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task<GetCardAbilitiesOverviewQueryResponse> Handle(GetCardAbilitiesOverviewQuery request, CancellationToken cancellationToken)
        {
            var cardAbilities = await _cardAbilityRepository.GetAllAsync()
                .Select(a => new CardAbilityOverviewDto
                {
                    Name = a.Name
                }).ToListAsync(cancellationToken: cancellationToken);

            return new GetCardAbilitiesOverviewQueryResponse(cardAbilities);
        }
    }
}
