using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilityDetails
{
    public class GetCardAbilityDetailsQuery : IRequest<GetCardAbilityDetailsQueryResponse>
    {
        public GetCardAbilityDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
