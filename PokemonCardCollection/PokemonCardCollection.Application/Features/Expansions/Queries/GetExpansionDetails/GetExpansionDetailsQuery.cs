using MediatR;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails
{
    public class GetExpansionDetailsQuery : IRequest<GetExpansionDetailsQueryResponse>
    {
        public GetExpansionDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
