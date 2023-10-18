using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack
{
    public class CreateCardAttackCommandResponse : ResponseBase
    {
        public CreateCardAttackCommandResponse() : base() { }

        public CreateCardAttackCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
