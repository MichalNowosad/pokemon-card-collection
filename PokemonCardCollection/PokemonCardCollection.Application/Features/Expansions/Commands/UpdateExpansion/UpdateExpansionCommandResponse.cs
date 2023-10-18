using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommandResponse : ResponseBase
    {
        public UpdateExpansionCommandResponse() : base() { }

        public UpdateExpansionCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
