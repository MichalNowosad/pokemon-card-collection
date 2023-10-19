using MediatR;
using Microsoft.AspNetCore.Http;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommand : IRequest<UpdatePokemonCardCommandResponse>
    {
        public UpdatePokemonCardCommand(UpdatePokemonCardDto pokemonCard, IFormFile pokemonCardImage)
        {
            PokemonCard = pokemonCard;
            PokemonCardImage = pokemonCardImage;
        }

        public UpdatePokemonCardDto PokemonCard { get; set; }
        public IFormFile PokemonCardImage { get; set; }
    }
}
