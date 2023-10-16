using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails
{
    public class GetPokemonCardDetailsQuery : IRequest<PokemonCardDetailsDto>
    {
        public Guid Id { get; set; }
    }
}