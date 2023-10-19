using MediatR;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility.Validators;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System.Net;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard.Validators;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Interfaces.Infrastructure;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardCommandHandler : IRequestHandler<UpdateTrainerCardCommand, UpdateTrainerCardCommandResponse>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;
        private readonly IFileService _fileService;

        public UpdateTrainerCardCommandHandler(ITrainerCardRepository trainerCardRepository,
            IFileService fileService)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<UpdateTrainerCardCommandResponse> Handle(UpdateTrainerCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrainerCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new UpdateTrainerCardCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var trainerCardDto = request.TrainerCard;

            var trainerCardToUpdate = await _trainerCardRepository.GetAsync(trainerCardDto.Id);

            if (trainerCardToUpdate != null)
            {
                _fileService.DeleteFile(trainerCardToUpdate.FileName, FileConstants.CardFolderName);
                var fileNameDto = await _fileService.SaveFile(request.TrainerCardImage, FileConstants.CardFolderName);

                trainerCardToUpdate.Name = trainerCardDto.Name;
                trainerCardToUpdate.Number = trainerCardDto.Number;
                trainerCardToUpdate.EffectDescription = trainerCardDto.EffectDescription;
                trainerCardToUpdate.Rarity = trainerCardDto.Rarity;
                trainerCardToUpdate.ExpansionId = trainerCardDto.ExpansionId;
                trainerCardToUpdate.IllustratorId = trainerCardDto.IllustratorId;
                trainerCardToUpdate.FileName = fileNameDto.FileName;
                trainerCardToUpdate.DisplayFileName = fileNameDto.DisplayFileName;

                await _trainerCardRepository.SaveChangesAsync();
            }

            return new UpdateTrainerCardCommandResponse();
        }
    }
}
