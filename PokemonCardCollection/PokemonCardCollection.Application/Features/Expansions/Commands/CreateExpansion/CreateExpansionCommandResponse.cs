using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionCommandResponse : ResponseBase
    {
        public CreateExpansionCommandResponse() : base() { }

        public CreateExpansionCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
