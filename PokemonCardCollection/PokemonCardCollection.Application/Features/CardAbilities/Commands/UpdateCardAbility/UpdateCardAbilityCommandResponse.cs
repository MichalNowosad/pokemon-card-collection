using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility
{
    public class UpdateCardAbilityCommandResponse : ResponseBase
    {
        public UpdateCardAbilityCommandResponse() : base() { }

        public UpdateCardAbilityCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
