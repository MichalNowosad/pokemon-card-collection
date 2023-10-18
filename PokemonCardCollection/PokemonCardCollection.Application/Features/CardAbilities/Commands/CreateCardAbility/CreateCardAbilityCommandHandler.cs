using MediatR;
using PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility.Validators;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using System.Net;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility
{
    public class CreateCardAbilityCommandHandler : IRequestHandler<CreateCardAbilityCommand, CreateCardAbilityCommandResponse>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public CreateCardAbilityCommandHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task<CreateCardAbilityCommandResponse> Handle(CreateCardAbilityCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCardAbilityCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new CreateCardAbilityCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var cardAbilityDto = request.CardAbility;

            var cardAbilityToCreate = new CardAbility
            {
                Name = cardAbilityDto.Name,
                Description = cardAbilityDto.Description
            };

            await _cardAbilityRepository.CreateAsync(cardAbilityToCreate);
            await _cardAbilityRepository.SaveChangesAsync();

            return new CreateCardAbilityCommandResponse();
        }
    }
}
