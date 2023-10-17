using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.CreateCardAbility
{
    public class CreateCardAbilityCommandHandler : IRequestHandler<CreateCardAbilityCommand, Guid>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public CreateCardAbilityCommandHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task<Guid> Handle(CreateCardAbilityCommand request, CancellationToken cancellationToken)
        {
            var cardAbilityDto = request.CardAbility;

            var cardAbilityToCreate = new CardAbility
            {
                Name = cardAbilityDto.Name,
                Description = cardAbilityDto.Description
            };

            await _cardAbilityRepository.CreateAsync(cardAbilityToCreate);
            await _cardAbilityRepository.SaveChangesAsync();

            return cardAbilityToCreate.Id;
        }
    }
}
