using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails
{
    public class GetExpansionDetailsQueryResponse : ResponseBase
    {
        public GetExpansionDetailsQueryResponse(ExpansionDetailsDto expansion) : base()
        {
            Expansion = expansion;
        }

        public ExpansionDetailsDto Expansion { get; set; }
    }
}
