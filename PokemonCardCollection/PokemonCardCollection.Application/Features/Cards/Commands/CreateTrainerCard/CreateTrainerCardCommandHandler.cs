using MediatR;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard.Validators;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using System.Net;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardCommandHandler : IRequestHandler<CreateTrainerCardCommand, CreateTrainerCardCommandResponse>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;
        private readonly IFileService _fileService;

        public CreateTrainerCardCommandHandler(ITrainerCardRepository trainerCardRepository,
            IFileService fileService)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<CreateTrainerCardCommandResponse> Handle(CreateTrainerCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTrainerCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new CreateTrainerCardCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var trainerCardDto = request.TrainerCard;

            var fileNameDto = await _fileService.SaveFile(request.TrainerCardImage, FileConstants.CardFolderName);

            var trainerCardToCreate = new TrainerCard
            {
                Name = trainerCardDto.Name,
                Number = trainerCardDto.Number,
                EffectDescription = trainerCardDto.EffectDescription,
                Rarity = trainerCardDto.Rarity,
                ExpansionId = trainerCardDto.ExpansionId,
                IllustratorId = trainerCardDto.IllustratorId,
                FileName = fileNameDto.FileName,
                DisplayFileName = fileNameDto.DisplayFileName
            };

            await _trainerCardRepository.CreateAsync(trainerCardToCreate);
            await _trainerCardRepository.SaveChangesAsync();

            return new CreateTrainerCardCommandResponse();
        }
    }
}
