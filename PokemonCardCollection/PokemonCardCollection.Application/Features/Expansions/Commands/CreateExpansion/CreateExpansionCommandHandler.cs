using MediatR;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard.Validators;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using System.Net;
using PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion.Validators;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionCommandHandler : IRequestHandler<CreateExpansionCommand, CreateExpansionCommandResponse>
    {
        private readonly IExpansionRepository _expansionRepository;

        public CreateExpansionCommandHandler(IExpansionRepository expansionRepository)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
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

            var expansionToCreate = new Expansion
            {
                Name = expansionDto.Name,
                CardsAmount = expansionDto.CardsAmount,
                ReleaseDate = expansionDto.ReleaseDate,
                Abbreviation = expansionDto.Abbreviation
            };

            await _expansionRepository.CreateAsync(expansionToCreate);
            await _expansionRepository.SaveChangesAsync();

            return new CreateExpansionCommandResponse();
        }
    }
}
