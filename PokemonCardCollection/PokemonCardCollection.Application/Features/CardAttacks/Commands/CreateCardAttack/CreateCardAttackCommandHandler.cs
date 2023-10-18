using MediatR;
using PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack.Validators;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;
using System.Net;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack
{
    public class CreateCardAttackCommandHandler : IRequestHandler<CreateCardAttackCommand, CreateCardAttackCommandResponse>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public CreateCardAttackCommandHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<CreateCardAttackCommandResponse> Handle(CreateCardAttackCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCardAttackCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var validationErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return new CreateCardAttackCommandResponse(HttpStatusCode.UnprocessableEntity, validationErrorMessages);
            }

            var cardAttackDto = request.CardAttack;

            var cardAttackToCreate = new CardAttack
            {
                Name = cardAttackDto.Name,
                Description = cardAttackDto.Description,
                Power = cardAttackDto.Power
            };

            await _cardAttackRepository.CreateAsync(cardAttackToCreate);
            await _cardAttackRepository.SaveChangesAsync();

            return new CreateCardAttackCommandResponse();
        }
    }
}
