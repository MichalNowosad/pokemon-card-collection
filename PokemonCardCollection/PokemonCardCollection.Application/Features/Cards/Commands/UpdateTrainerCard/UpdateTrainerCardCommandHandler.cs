using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardCommandHandler : IRequestHandler<UpdateTrainerCardCommand>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;

        public UpdateTrainerCardCommandHandler(ITrainerCardRepository trainerCardRepository)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
        }

        public async Task Handle(UpdateTrainerCardCommand request, CancellationToken cancellationToken)
        {
            var trainerCardDto = request.TrainerCard;

            var trainerCardToUpdate = await _trainerCardRepository.GetAsync(trainerCardDto.Id);

            if (trainerCardToUpdate != null)
            {
                trainerCardToUpdate.Name = trainerCardDto.Name;
                trainerCardToUpdate.Number = trainerCardDto.Number;
                trainerCardToUpdate.EffectDescription = trainerCardDto.EffectDescription;
                trainerCardToUpdate.Rarity = trainerCardDto.Rarity;
                trainerCardToUpdate.ExpansionId = trainerCardDto.ExpansionId;
                trainerCardToUpdate.IllustratorId = trainerCardDto.IllustratorId;

                await _trainerCardRepository.SaveChangesAsync();
            }
        }
    }
}
