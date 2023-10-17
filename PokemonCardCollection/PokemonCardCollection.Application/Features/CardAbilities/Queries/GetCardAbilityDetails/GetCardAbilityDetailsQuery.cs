using MediatR;

namespace PokemonCardCollection.Application.Features.CardAbilities.Queries.GetCardAbilityDetails
{
    public class GetCardAbilityDetailsQuery : IRequest<CardAbilityDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
