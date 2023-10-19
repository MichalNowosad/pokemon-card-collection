using MediatR;
using Microsoft.AspNetCore.Http;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard
{
    public class CreatePokemonCardCommand : IRequest<CreatePokemonCardCommandResponse>
    {
        public CreatePokemonCardCommand(CreatePokemonCardDto pokemonCard, IFormFile pokemonCardImage)
        {
            PokemonCard = pokemonCard;
            PokemonCardImage = pokemonCardImage;
        }

        public CreatePokemonCardDto PokemonCard { get; set; }
        public IFormFile PokemonCardImage { get; set; }
    }
}
