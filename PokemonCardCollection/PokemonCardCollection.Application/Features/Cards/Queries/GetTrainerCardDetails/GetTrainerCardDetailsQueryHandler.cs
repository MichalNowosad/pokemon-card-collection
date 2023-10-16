using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetTrainerCardDetails
{
    public class GetTrainerCardDetailsQueryHandler : IRequestHandler<GetTrainerCardDetailsQuery, TrainerCardDetailsDto>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;

        public GetTrainerCardDetailsQueryHandler(ITrainerCardRepository trainerCardRepository)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
        }

        public async Task<TrainerCardDetailsDto> Handle(GetTrainerCardDetailsQuery request, CancellationToken cancellationToken)
        {
            var allTrainerCards = _trainerCardRepository.GetAllAsync();

            var trainerCard = await allTrainerCards.Select(c => new TrainerCardDetailsDto
            {
                Id = c.Id,
                Name = c.Name,
                Number = c.Number,
                Description = c.EffectDescription,
                Rarity = c.Rarity,
                ExpansionName = c.Expansion != null ? c.Expansion.Name : string.Empty,
                IllustratorName = c.Illustrator != null ? c.Illustrator.Name : string.Empty,
            }).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

            return trainerCard;
        }
    }
}
