using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard.Validators;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System.Net;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommandHandler : IRequestHandler<UpdatePokemonCardCommand, UpdatePokemonCardCommandResponse>
    {
        private readonly IPokemonCardRepository _pokemonCardRepository;
        private readonly ICardAttackRepository _cardAttackRepository;
        private readonly IFileService _fileService;

        public UpdatePokemonCardCommandHandler(IPokemonCardRepository pokemonCardRepository,
            ICardAttackRepository cardAttackRepository,
            IFileService fileService)
        {
            _pokemonCardRepository = pokemonCardRepository ?? throw new ArgumentNullException(nameof(pokemonCardRepository));
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<UpdatePokemonCardCommandResponse> Handle(UpdatePokemonCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePokemonCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new UpdatePokemonCardCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var pokemonCardDto = request.PokemonCard;

            var pokemonCardToUpdate = await _pokemonCardRepository.GetAsync(pokemonCardDto.Id);

            if (pokemonCardToUpdate != null)
            {
                _fileService.DeleteFile(pokemonCardToUpdate.FileName, FileConstants.CardFolderName);
                var fileNameDto = await _fileService.SaveFile(request.PokemonCardImage, FileConstants.CardFolderName);

                pokemonCardToUpdate.Name = pokemonCardDto.Name;
                pokemonCardToUpdate.Number = pokemonCardDto.Number;
                pokemonCardToUpdate.Rarity = pokemonCardDto.Rarity;
                pokemonCardToUpdate.ExpansionId = pokemonCardDto.ExpansionId;
                pokemonCardToUpdate.IllustratorId = pokemonCardDto.IllustratorId;
                pokemonCardToUpdate.HealthPoints = pokemonCardDto.HealthPoints;
                pokemonCardToUpdate.PokemonDescription = pokemonCardDto.PokemonDescription;
                pokemonCardToUpdate.EnergyType = pokemonCardDto.EnergyType;
                pokemonCardToUpdate.AbilityId = pokemonCardDto.AbilityId;
                pokemonCardToUpdate.Attacks = await _cardAttackRepository.GetByIds(pokemonCardDto.AttackIds).ToListAsync(cancellationToken: cancellationToken);
                pokemonCardToUpdate.FileName = fileNameDto.FileName;
                pokemonCardToUpdate.DisplayFileName = fileNameDto.DisplayFileName;

                await _pokemonCardRepository.SaveChangesAsync();
            }

            return new UpdatePokemonCardCommandResponse();
        }
    }
}
