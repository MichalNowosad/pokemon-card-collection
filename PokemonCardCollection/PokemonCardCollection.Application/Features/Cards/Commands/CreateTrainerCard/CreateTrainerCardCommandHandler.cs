using MediatR;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard.Validators;
using PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using System.Net;
using PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard.Validators;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardCommandHandler : IRequestHandler<CreateTrainerCardCommand, CreateTrainerCardCommandResponse>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;

        public CreateTrainerCardCommandHandler(ITrainerCardRepository trainerCardRepository)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
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

            var trainerCardToCreate = new TrainerCard
            {
                Name = trainerCardDto.Name,
                Number = trainerCardDto.Number,
                EffectDescription = trainerCardDto.EffectDescription,
                Rarity = trainerCardDto.Rarity,
                ExpansionId = trainerCardDto.ExpansionId,
                IllustratorId = trainerCardDto.IllustratorId
            };

            await _trainerCardRepository.CreateAsync(trainerCardToCreate);
            await _trainerCardRepository.SaveChangesAsync();

            return new CreateTrainerCardCommandResponse();
        }
    }
}
