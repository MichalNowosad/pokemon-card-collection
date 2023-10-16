using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommand : IRequest
    {
        public UpdatePokemonCardDto? PokemonCard { get; set; }
    }
}
