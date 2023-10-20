using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails
{
    public class GetCardAttackDetailsQuery : IRequest<GetCardAttackDetailsQueryResponse>
    {
        public GetCardAttackDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
