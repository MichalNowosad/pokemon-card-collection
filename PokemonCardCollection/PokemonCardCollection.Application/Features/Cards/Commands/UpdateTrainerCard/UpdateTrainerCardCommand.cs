using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardCommand : IRequest<UpdateTrainerCardCommandResponse>
    {
        public UpdateTrainerCardCommand(IFormCollection form)
        {
            TrainerCard = JsonConvert.DeserializeObject<UpdateTrainerCardDto>(form["pokemonCard"].ToString()) ?? new UpdateTrainerCardDto();
            TrainerCardImage = form.Files[0];
        }

        public UpdateTrainerCardDto TrainerCard { get; set; }
        public IFormFile TrainerCardImage { get; set; }

    }
}
