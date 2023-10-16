using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails
{
    public class GetCardAttackDetailsCommandHandler : IRequestHandler<GetCardAttackDetailsCommand, CardAttackDetailsDto>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public GetCardAttackDetailsCommandHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<CardAttackDetailsDto> Handle(GetCardAttackDetailsCommand request, CancellationToken cancellationToken)
        {
            var cardAttack = await _cardAttackRepository.GetAllAsync()
                .Select(a => new CardAttackDetailsDto
                {
                    Id = a.Id,
                    Description = a.Description,
                    Name = a.Name,
                    Power = a.Power
                }).FirstOrDefaultAsync(a => a.Id == request.CardAttackId);

            return cardAttack;
        }
    }
}
