using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.CreateCardAttack
{
    public class CreateCardAttackCommandHandler : IRequestHandler<CreateCardAttackCommand, Guid>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public CreateCardAttackCommandHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<Guid> Handle(CreateCardAttackCommand request, CancellationToken cancellationToken)
        {
            var cardAttackDto = request.CardAttack;

            var cardAttackToCreate = new CardAttack
            {
                Name = cardAttackDto.Name,
                Description = cardAttackDto.Description,
                Power = cardAttackDto.Power
            };

            await _cardAttackRepository.CreateAsync(cardAttackToCreate);
            await _cardAttackRepository.SaveChangesAsync();

            return cardAttackToCreate.Id;
        }
    }
}
