using MediatR;
using Microsoft.AspNetCore.Http;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardCommand : IRequest<UpdateTrainerCardCommandResponse>
    {
        public UpdateTrainerCardCommand(UpdateTrainerCardDto trainerCard, IFormFile trainerCardImage)
        {
            TrainerCard = trainerCard;
            TrainerCardImage = trainerCardImage;
        }

        public UpdateTrainerCardDto TrainerCard { get; set; }
        public IFormFile TrainerCardImage { get; set; }

    }
}
