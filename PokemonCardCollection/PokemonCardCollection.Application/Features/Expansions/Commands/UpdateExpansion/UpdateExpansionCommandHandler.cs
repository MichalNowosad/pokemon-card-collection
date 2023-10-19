using MediatR;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion.Validators;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System.Net;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommandHandler : IRequestHandler<UpdateExpansionCommand, UpdateExpansionCommandResponse>
    {
        private readonly IExpansionRepository _expansionRepository;
        private readonly IFileService _fileService;

        public UpdateExpansionCommandHandler(IExpansionRepository expansionRepository,
            IFileService fileService)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<UpdateExpansionCommandResponse> Handle(UpdateExpansionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExpansionCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new UpdateExpansionCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var expansionDto = request.Expansion;

            var expansionToUpdate = await _expansionRepository.GetAsync(expansionDto.Id);

            if (expansionToUpdate != null)
            {
                _fileService.DeleteFile(expansionToUpdate.FileName, FileConstants.CardFolderName);
                var fileNameDto = await _fileService.SaveFile(request.ExpansionImage, FileConstants.ExpansionFolderName);

                expansionToUpdate.Name = expansionDto.Name;
                expansionToUpdate.CardsAmount = expansionDto.CardsAmount;
                expansionToUpdate.ReleaseDate = expansionDto.ReleaseDate;
                expansionToUpdate.Abbreviation = expansionDto.Abbreviation;
                expansionToUpdate.FileName = fileNameDto.FileName;
                expansionToUpdate.DisplayFileName = fileNameDto.DisplayFileName;

                await _expansionRepository.SaveChangesAsync();
            }

            return new UpdateExpansionCommandResponse();
        }
    }
}
