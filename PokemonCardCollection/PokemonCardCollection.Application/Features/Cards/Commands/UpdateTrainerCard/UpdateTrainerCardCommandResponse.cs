using PokemonCardCollection.Application.Responses;
using System.Net;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardCommandResponse : ResponseBase
    {
        public UpdateTrainerCardCommandResponse() : base() { }

        public UpdateTrainerCardCommandResponse(HttpStatusCode statusCode, IEnumerable<string> validationErrors) : base(statusCode, validationErrors) { }
    }
}
