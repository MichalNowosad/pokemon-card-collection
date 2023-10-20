using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetTrainerCardDetails
{
    public class GetTrainerCardDetailsQueryHandler : IRequestHandler<GetTrainerCardDetailsQuery, GetTrainerCardDetailsQueryResponse>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;
        private readonly IFileService _fileService;

        public GetTrainerCardDetailsQueryHandler(ITrainerCardRepository trainerCardRepository,
            IFileService fileService)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<GetTrainerCardDetailsQueryResponse> Handle(GetTrainerCardDetailsQuery request, CancellationToken cancellationToken)
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
                FileName = c.FileName
            }).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

            trainerCard.FileStream = await _fileService.GetFileStream(trainerCard.FileName, FileConstants.CardFolderName);

            return new GetTrainerCardDetailsQueryResponse(trainerCard);
        }
    }
}
