using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommandResponse : ResponseBase
    {
        public UpdatePokemonCardCommandResponse() : base() { }

        public UpdatePokemonCardCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
