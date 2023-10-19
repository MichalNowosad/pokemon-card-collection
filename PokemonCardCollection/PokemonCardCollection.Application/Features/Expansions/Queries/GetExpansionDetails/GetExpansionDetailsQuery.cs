using MediatR;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails
{
    public class GetExpansionDetailsQuery : IRequest<ExpansionDetailsDto>
    {
        public GetExpansionDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
