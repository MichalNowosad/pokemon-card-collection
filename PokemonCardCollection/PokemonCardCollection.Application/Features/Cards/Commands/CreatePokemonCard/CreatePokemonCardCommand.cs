using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard
{
    public class CreatePokemonCardCommand : IRequest<CreatePokemonCardCommandResponse>
    {
        public CreatePokemonCardCommand(IFormCollection form)
        {
            PokemonCard = JsonConvert.DeserializeObject<CreatePokemonCardDto>(form["pokemonCard"].ToString()) ?? new CreatePokemonCardDto();
            PokemonCardImage = form.Files[0];
        }

        public CreatePokemonCardDto PokemonCard { get; set; }
        public IFormFile PokemonCardImage { get; set; }
    }
}
