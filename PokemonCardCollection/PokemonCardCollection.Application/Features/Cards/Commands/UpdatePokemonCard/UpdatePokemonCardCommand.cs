using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommand : IRequest<UpdatePokemonCardCommandResponse>
    {
        public UpdatePokemonCardCommand(IFormCollection form)
        {
            PokemonCard = JsonConvert.DeserializeObject<UpdatePokemonCardDto>(form["pokemonCard"].ToString()) ?? new UpdatePokemonCardDto();
            PokemonCardImage = form.Files[0];
        }

        public UpdatePokemonCardDto PokemonCard { get; set; }
        public IFormFile PokemonCardImage { get; set; }
    }
}
