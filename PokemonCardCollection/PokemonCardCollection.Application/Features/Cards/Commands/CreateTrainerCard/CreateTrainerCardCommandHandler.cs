using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardCommandHandler : IRequestHandler<CreateTrainerCardCommand, Guid>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;

        public CreateTrainerCardCommandHandler(ITrainerCardRepository trainerCardRepository)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
        }

        public async Task<Guid> Handle(CreateTrainerCardCommand request, CancellationToken cancellationToken)
        {
            var trainerCardDto = request.TrainerCard;

            var trainerCardToCreate = new TrainerCard
            {
                Name = trainerCardDto.Name,
                Number = trainerCardDto.Number,
                EffectDescription = trainerCardDto.EffectDescription,
                Rarity = trainerCardDto.Rarity,
                ExpansionId = trainerCardDto.ExpansionId,
                IllustratorId = trainerCardDto.IllustratorId
            };

            await _trainerCardRepository.CreateAsync(trainerCardToCreate);
            await _trainerCardRepository.SaveChangesAsync();

            return trainerCardToCreate.Id;
        }
    }
}
