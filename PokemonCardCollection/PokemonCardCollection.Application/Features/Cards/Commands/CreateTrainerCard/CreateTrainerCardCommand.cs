using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardCommand : IRequest<Guid>
    {
        public CreateTrainerCardDto? TrainerCard { get; set; }
    }
}
