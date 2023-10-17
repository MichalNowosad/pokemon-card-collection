using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilitiesOverview
{
    public class GetCardAbilitiesOverviewQueryHandler : IRequestHandler<GetCardAbilitiesOverviewQuery, IEnumerable<CardAbilityOverviewDto>>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public GetCardAbilitiesOverviewQueryHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task<IEnumerable<CardAbilityOverviewDto>> Handle(GetCardAbilitiesOverviewQuery request, CancellationToken cancellationToken)
        {
            var cardAbilities = _cardAbilityRepository.GetAllAsync();

            return await cardAbilities.Select(a => new CardAbilityOverviewDto
            {
                Name = a.Name
            }).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
