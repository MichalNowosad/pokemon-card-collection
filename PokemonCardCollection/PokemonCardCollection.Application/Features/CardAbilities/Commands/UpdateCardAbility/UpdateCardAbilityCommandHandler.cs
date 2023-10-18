using MediatR;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility.Validators;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility.Validators;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility
{
    public class UpdateCardAbilityCommandHandler : IRequestHandler<UpdateCardAbilityCommand, UpdateCardAbilityCommandResponse>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public UpdateCardAbilityCommandHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task<UpdateCardAbilityCommandResponse> Handle(UpdateCardAbilityCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCardAbilityCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new UpdateCardAbilityCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var cardAbilityDto = request.CardAbility;

            var cardAbilityToUpdate = await _cardAbilityRepository.GetAsync(cardAbilityDto.Id);

            if (cardAbilityToUpdate != null)
            {
                cardAbilityToUpdate.Name = cardAbilityDto.Name;
                cardAbilityToUpdate.Description = cardAbilityDto.Description;

                await _cardAbilityRepository.SaveChangesAsync();
            }

            return new UpdateCardAbilityCommandResponse();
        }
    }
}
