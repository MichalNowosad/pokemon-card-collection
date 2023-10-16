using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion
{
    public class GetCardsOverviewByExpansionQueryHandler : IRequestHandler<GetCardsOverviewByExpansionQuery, IEnumerable<CardOverviewDto>>
    {
        private readonly ITrainerCardRepository _cardRepository;

        public GetCardsOverviewByExpansionQueryHandler(ITrainerCardRepository cardRepository)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        }

        public async Task<IEnumerable<CardOverviewDto>> Handle(GetCardsOverviewByExpansionQuery request, CancellationToken cancellationToken)
        {
            var cards = _cardRepository.GetByExpansionId(request.ExpansionId);

            return await cards.Select(c => new CardOverviewDto
            {
                Id = c.Id,
                Number = c.Number,
                Name = c.Name,
                ImageUrl = c.DisplayFileName
            }).ToListAsync();
        }
    }
}
