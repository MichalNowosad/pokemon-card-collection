using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails
{
    public class GetCardAttackDetailsQuery : IRequest<CardAttackDetailsDto>
    {
        public GetCardAttackDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
