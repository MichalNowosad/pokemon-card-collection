using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttacksOverview
{
    public class GetCardAttacksOverviewCommandHandler : IRequestHandler<GetCardAttacksOverviewCommand, IEnumerable<CardAttackOverviewDto>>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public GetCardAttacksOverviewCommandHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<IEnumerable<CardAttackOverviewDto>> Handle(GetCardAttacksOverviewCommand request, CancellationToken cancellationToken)
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
