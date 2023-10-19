using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardCommand : IRequest<CreateTrainerCardCommandResponse>
    {
        public CreateTrainerCardCommand(IFormCollection form)
        {
            TrainerCard = JsonConvert.DeserializeObject<CreateTrainerCardDto>(form["pokemonCard"].ToString()) ?? new CreateTrainerCardDto();
            TrainerCardImage = form.Files[0];
        }

        public CreateTrainerCardDto TrainerCard { get; set; }
        public IFormFile TrainerCardImage { get; set; }

    }
}
