using MediatR;
using PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion.Validators;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System.Net;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommandHandler : IRequestHandler<UpdateExpansionCommand, UpdateExpansionCommandResponse>
    {
        private readonly IExpansionRepository _expansionRepository;

        public UpdateExpansionCommandHandler(IExpansionRepository expansionRepository)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
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
                expansionToUpdate.Name = expansionDto.Name;
                expansionToUpdate.CardsAmount = expansionDto.CardsAmount;
                expansionToUpdate.ReleaseDate = expansionDto.ReleaseDate;
                expansionToUpdate.Abbreviation = expansionDto.Abbreviation;

                await _expansionRepository.SaveChangesAsync();
            }

            return new UpdateExpansionCommandResponse();
        }
    }
}
