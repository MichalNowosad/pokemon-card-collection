using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttacksOverview
{
    public class GetCardAttacksOverviewQueryHandler : IRequestHandler<GetCardAttacksOverviewQuery, GetCardAttacksOverviewQueryResponse>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public GetCardAttacksOverviewQueryHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<GetCardAttacksOverviewQueryResponse> Handle(GetCardAttacksOverviewQuery request, CancellationToken cancellationToken)
        {
            var cardAttacks = await _cardAttackRepository.GetAllAsync().Select(a => new CardAttackOverviewDto
            {
                Name = a.Name,
                Power = a.Power
            }).ToListAsync(cancellationToken: cancellationToken);

            return new GetCardAttacksOverviewQueryResponse(cardAttacks);
        }
    }
}
