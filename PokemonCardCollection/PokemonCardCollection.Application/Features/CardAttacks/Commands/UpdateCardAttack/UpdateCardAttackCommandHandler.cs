using MediatR;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility.Validators;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System.Net;
using PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack.Validators;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack
{
    public class UpdateCardAttackCommandHandler : IRequestHandler<UpdateCardAttackCommand, UpdateCardAttackCommandResponse>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public UpdateCardAttackCommandHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<UpdateCardAttackCommandResponse> Handle(UpdateCardAttackCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCardAttackCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new UpdateCardAttackCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var cardAttackDto = request.CardAttack;

            var cardAttackToUpdate = await _cardAttackRepository.GetAsync(cardAttackDto.Id);

            if (cardAttackToUpdate != null)
            {
                cardAttackToUpdate.Name = cardAttackDto.Name;
                cardAttackToUpdate.Description = cardAttackDto.Description;
                cardAttackToUpdate.Power = cardAttackDto.Power;

                await _cardAttackRepository.SaveChangesAsync();
            }

            return new UpdateCardAttackCommandResponse();
        }
    }
}
