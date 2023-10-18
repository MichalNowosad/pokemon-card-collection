using MediatR;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility.Validators;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System.Net;
using PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard.Validators;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardCommandHandler : IRequestHandler<UpdateTrainerCardCommand, UpdateTrainerCardCommandResponse>
    {
        private readonly ITrainerCardRepository _trainerCardRepository;

        public UpdateTrainerCardCommandHandler(ITrainerCardRepository trainerCardRepository)
        {
            _trainerCardRepository = trainerCardRepository ?? throw new ArgumentNullException(nameof(trainerCardRepository));
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
                trainerCardToUpdate.Name = trainerCardDto.Name;
                trainerCardToUpdate.Number = trainerCardDto.Number;
                trainerCardToUpdate.EffectDescription = trainerCardDto.EffectDescription;
                trainerCardToUpdate.Rarity = trainerCardDto.Rarity;
                trainerCardToUpdate.ExpansionId = trainerCardDto.ExpansionId;
                trainerCardToUpdate.IllustratorId = trainerCardDto.IllustratorId;

                await _trainerCardRepository.SaveChangesAsync();
            }

            return new UpdateTrainerCardCommandResponse();
        }
    }
}
