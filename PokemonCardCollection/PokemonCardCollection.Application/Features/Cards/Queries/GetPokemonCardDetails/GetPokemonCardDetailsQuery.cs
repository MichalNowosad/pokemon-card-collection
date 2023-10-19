using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails
{
    public class GetPokemonCardDetailsQuery : IRequest<PokemonCardDetailsDto>
    {
        public GetPokemonCardDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}