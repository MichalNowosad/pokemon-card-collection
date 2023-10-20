using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion
{
    public class GetCardsOverviewByExpansionQueryHandler : IRequestHandler<GetCardsOverviewByExpansionQuery, GetCardsOverviewByExpansionQueryResponse>
    {
        private readonly ITrainerCardRepository _cardRepository;

        public GetCardsOverviewByExpansionQueryHandler(ITrainerCardRepository cardRepository)
        {
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
        }

        public async Task<GetCardsOverviewByExpansionQueryResponse> Handle(GetCardsOverviewByExpansionQuery request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetByExpansionId(request.ExpansionId)
                .Select(c => new CardOverviewDto
                {
                    Id = c.Id,
                    Number = c.Number,
                    Name = c.Name,
                    ImageUrl = c.DisplayFileName
                }).ToListAsync();

            return new GetCardsOverviewByExpansionQueryResponse(cards);
        }
    }
}
