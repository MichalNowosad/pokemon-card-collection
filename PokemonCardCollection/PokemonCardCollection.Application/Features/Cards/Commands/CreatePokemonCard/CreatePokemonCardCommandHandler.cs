using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard.Validators;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using System.Net;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard
{
    public class CreatePokemonCardCommandHandler : IRequestHandler<CreatePokemonCardCommand, CreatePokemonCardCommandResponse>
    {
        private readonly IPokemonCardRepository _pokemonCardRepository;
        private readonly ICardAttackRepository _cardAttackRepository;
        private readonly IFileService _fileService;

        public CreatePokemonCardCommandHandler(IPokemonCardRepository pokemonCardRepository,
            ICardAttackRepository cardAttackRepository,
            IFileService fileService)
        {
            _pokemonCardRepository = pokemonCardRepository ?? throw new ArgumentNullException(nameof(pokemonCardRepository));
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<CreatePokemonCardCommandResponse> Handle(CreatePokemonCardCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePokemonCardCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new CreatePokemonCardCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var pokemonCardDto = request.PokemonCard;

            var cardAttacks = await _cardAttackRepository.GetByIds(pokemonCardDto.AttackIds).ToListAsync(cancellationToken);

            var fileNameDto = await _fileService.SaveFile(request.PokemonCardImage, FileConstants.CardFolderName);

            var pokemonCardToCreate = new PokemonCard
            {
                Name = pokemonCardDto.Name,
                Number = pokemonCardDto.Number,
                Rarity = pokemonCardDto.Rarity,
                ExpansionId = pokemonCardDto.ExpansionId,
                IllustratorId = pokemonCardDto.IllustratorId,
                HealthPoints = pokemonCardDto.HealthPoints,
                PokemonDescription = pokemonCardDto.PokemonDescription,
                EnergyType = pokemonCardDto.EnergyType,
                AbilityId = pokemonCardDto.AbilityId,
                Attacks = cardAttacks,
                FileName = fileNameDto.FileName,
                DisplayFileName = fileNameDto.DisplayFileName
            };

            await _pokemonCardRepository.CreateAsync(pokemonCardToCreate);
            await _pokemonCardRepository.SaveChangesAsync();

            return new CreatePokemonCardCommandResponse();
        }
    }
}
