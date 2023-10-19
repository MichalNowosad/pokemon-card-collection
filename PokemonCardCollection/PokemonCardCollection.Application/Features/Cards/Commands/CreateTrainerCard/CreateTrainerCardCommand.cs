using MediatR;
using Microsoft.AspNetCore.Http;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardCommand : IRequest<CreateTrainerCardCommandResponse>
    {
        public CreateTrainerCardCommand(CreateTrainerCardDto trainerCard, IFormFile trainerCardImage)
        {
            TrainerCard = trainerCard;
            TrainerCardImage = trainerCardImage;
        }

        public CreateTrainerCardDto TrainerCard { get; set; }
        public IFormFile TrainerCardImage { get; set; }

    }
}
