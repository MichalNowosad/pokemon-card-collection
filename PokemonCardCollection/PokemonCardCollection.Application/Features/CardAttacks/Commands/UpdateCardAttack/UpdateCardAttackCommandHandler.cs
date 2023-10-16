using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack
{
    public class UpdateCardAttackCommandHandler : IRequestHandler<UpdateCardAttackCommand>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public UpdateCardAttackCommandHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task Handle(UpdateCardAttackCommand request, CancellationToken cancellationToken)
        {
            var cardAttackDto = request.CardAttack;

            var cardAttackToUpdate = await _cardAttackRepository.GetAsync(cardAttackDto.Id);

            if (cardAttackToUpdate != null)
            {
                cardAttackToUpdate.Name = cardAttackDto.Name;
                cardAttackToUpdate.Description = cardAttackDto.Description;
                cardAttackToUpdate.Power = cardAttackDto.Power;

                await _cardAttackRepository.SaveChangesAsync();
            }
        }
    }
}
