using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails
{
    public class GetCardAttackDetailsQueryHandler : IRequestHandler<GetCardAttackDetailsQuery, GetCardAttackDetailsQueryResponse>
    {
        private readonly ICardAttackRepository _cardAttackRepository;

        public GetCardAttackDetailsQueryHandler(ICardAttackRepository cardAttackRepository)
        {
            _cardAttackRepository = cardAttackRepository ?? throw new ArgumentNullException(nameof(cardAttackRepository));
        }

        public async Task<GetCardAttackDetailsQueryResponse> Handle(GetCardAttackDetailsQuery request, CancellationToken cancellationToken)
        {
            var cardAttack = await _cardAttackRepository.GetAllAsync()
                .Select(a => new CardAttackDetailsDto
                {
                    Id = a.Id,
                    Description = a.Description,
                    Name = a.Name,
                    Power = a.Power
                }).FirstOrDefaultAsync(a => a.Id == request.Id);

            return new GetCardAttackDetailsQueryResponse(cardAttack);
        }
    }
}
