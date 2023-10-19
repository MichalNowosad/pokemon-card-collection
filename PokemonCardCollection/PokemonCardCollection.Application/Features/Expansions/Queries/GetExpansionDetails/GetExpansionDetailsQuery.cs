using MediatR;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails
{
    public class GetExpansionDetailsQuery : IRequest<ExpansionDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
