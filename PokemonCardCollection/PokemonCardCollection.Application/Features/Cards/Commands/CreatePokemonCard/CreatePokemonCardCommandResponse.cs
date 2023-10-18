using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard
{
    public class CreatePokemonCardCommandResponse : ResponseBase
    {
        public CreatePokemonCardCommandResponse() : base() { }

        public CreatePokemonCardCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
