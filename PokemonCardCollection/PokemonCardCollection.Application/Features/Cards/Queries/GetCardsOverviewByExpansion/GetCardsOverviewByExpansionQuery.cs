using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetCardsOverviewByExpansion
{
    public class GetCardsOverviewByExpansionQuery : IRequest<GetCardsOverviewByExpansionQueryResponse>
    {
        public GetCardsOverviewByExpansionQuery(Guid expansionId)
        {
            ExpansionId = expansionId;
        }

        public Guid ExpansionId { get; set; }
    }
}
