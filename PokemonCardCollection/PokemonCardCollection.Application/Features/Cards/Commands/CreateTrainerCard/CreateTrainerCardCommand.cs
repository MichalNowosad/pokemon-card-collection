using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardCommand : IRequest<CreateTrainerCardCommandResponse>
    {
        public CreateTrainerCardDto TrainerCard { get; set; } = new CreateTrainerCardDto();
    }
}
