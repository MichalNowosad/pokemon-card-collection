using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility
{
    public class CreateCardAbilityCommandResponse : ResponseBase
    {
        public CreateCardAbilityCommandResponse() : base() { }

        public CreateCardAbilityCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
