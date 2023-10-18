using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack
{
    public class UpdateCardAttackCommandResponse : ResponseBase
    {
        public UpdateCardAttackCommandResponse() : base() { }

        public UpdateCardAttackCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
