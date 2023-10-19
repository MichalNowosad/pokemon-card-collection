using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion
{
    public class GetCardsOverviewByExpansionQuery : IRequest<IEnumerable<CardOverviewDto>>
    {
        public GetCardsOverviewByExpansionQuery(Guid expansionId)
        {
            ExpansionId = expansionId;
        }

        public Guid ExpansionId { get; set; }
    }
}
