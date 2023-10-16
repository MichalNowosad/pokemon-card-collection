using MediatR;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails
{
    public class GetCardAttackDetailsCommand : IRequest<CardAttackDetailsDto>
    {
        public Guid CardAttackId { get; set; }
    }
}
