using MediatR;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion.Validators;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using System.Net;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionCommandHandler : IRequestHandler<CreateExpansionCommand, CreateExpansionCommandResponse>
    {
        private readonly IExpansionRepository _expansionRepository;
        private readonly IFileService _fileService;

        public CreateExpansionCommandHandler(IExpansionRepository expansionRepository,
            IFileService fileService)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<CreateExpansionCommandResponse> Handle(CreateExpansionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateExpansionCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new CreateExpansionCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var expansionDto = request.Expansion;

            var fileNameDto = await _fileService.SaveFile(request.ExpansionImage, FileConstants.ExpansionFolderName);

            var expansionToCreate = new Expansion
            {
                Name = expansionDto.Name,
                CardsAmount = expansionDto.CardsAmount,
                ReleaseDate = expansionDto.ReleaseDate,
                Abbreviation = expansionDto.Abbreviation,
                FileName = fileNameDto.FileName,
                DisplayFileName = fileNameDto.DisplayFileName
            };

            await _expansionRepository.CreateAsync(expansionToCreate);
            await _expansionRepository.SaveChangesAsync();

            return new CreateExpansionCommandResponse();
        }
    }
}
