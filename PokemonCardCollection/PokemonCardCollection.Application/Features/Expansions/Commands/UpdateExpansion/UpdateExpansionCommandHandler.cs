using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommandHandler : IRequestHandler<UpdateExpansionCommand>
    {
        private readonly IExpansionRepository _expansionRepository;

        public UpdateExpansionCommandHandler(IExpansionRepository expansionRepository)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
        }

        public async Task Handle(UpdateExpansionCommand request, CancellationToken cancellationToken)
        {
            var expansionDto = request.Expansion;

            var expansionToUpdate = await _expansionRepository.GetAsync(expansionDto.Id);

            if (expansionToUpdate != null)
            {
                expansionToUpdate.Name = expansionDto.Name;
                expansionToUpdate.CardsAmount = expansionDto.CardsAmount;
                expansionToUpdate.ReleaseDate = expansionDto.ReleaseDate;
                expansionToUpdate.Abbreviation = expansionDto.Abbreviation;

                await _expansionRepository.SaveChangesAsync();
            }
        }
    }
}
