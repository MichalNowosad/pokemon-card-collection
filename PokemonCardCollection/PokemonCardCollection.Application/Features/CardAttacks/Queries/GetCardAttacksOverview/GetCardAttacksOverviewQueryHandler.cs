using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttacksOverview
{
    public class GetCardAttacksOverviewQueryHandler : IRequestHandler<GetCardAttacksOverviewQuery, IEnumerable<CardAttackOverviewDto>>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public GetCardAttacksOverviewQueryHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<IEnumerable<CardAttackOverviewDto>> Handle(GetCardAttacksOverviewQuery request, CancellationToken cancellationToken)
        {
            var cardAttacks = _cardAttackRepository.GetAllAsync();

            return await cardAttacks.Select(a => new CardAttackOverviewDto
            {
                Name = a.Name,
                Power = a.Power
            }).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
