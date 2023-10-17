using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility
{
    public class UpdateCardAbilityCommandHandler : IRequestHandler<UpdateCardAbilityCommand>
    {
        private readonly ICardAbilityRepository _cardAbilityRepository;

        public UpdateCardAbilityCommandHandler(ICardAbilityRepository cardAbilityRepository)
        {
            _cardAbilityRepository = cardAbilityRepository ?? throw new ArgumentNullException(nameof(cardAbilityRepository));
        }

        public async Task Handle(UpdateCardAbilityCommand request, CancellationToken cancellationToken)
        {
            var cardAbilityDto = request.CardAbility;

            var cardAbilityToUpdate = await _cardAbilityRepository.GetAsync(cardAbilityDto.Id);

            if (cardAbilityToUpdate != null)
            {
                cardAbilityToUpdate.Name = cardAbilityDto.Name;
                cardAbilityToUpdate.Description = cardAbilityDto.Description;

                await _cardAbilityRepository.SaveChangesAsync();
            }
        }
    }
}
