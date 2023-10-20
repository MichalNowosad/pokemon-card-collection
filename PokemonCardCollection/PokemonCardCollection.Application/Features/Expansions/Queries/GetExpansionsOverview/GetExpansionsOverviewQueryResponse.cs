using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionsOverview
{
    public class GetExpansionsOverviewQueryResponse : ResponseBase
    {
        public GetExpansionsOverviewQueryResponse(IEnumerable<ExpansionOverviewDto> expansions) : base()
        {
            Expansions = expansions;
        }

        public IEnumerable<ExpansionOverviewDto> Expansions { get; set; }
    }
}
