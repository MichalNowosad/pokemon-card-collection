using MediatR;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionCommandHandler : IRequestHandler<CreateExpansionCommand, Guid>
    {
        private readonly IExpansionRepository _expansionRepository;

        public CreateExpansionCommandHandler(IExpansionRepository expansionRepository)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
        }

        public async Task<Guid> Handle(CreateExpansionCommand request, CancellationToken cancellationToken)
        {
            var expansionDto = request.Expansion;

            var expansionToCreate = new Expansion
            {
                Name = expansionDto.Name,
                CardsAmount = expansionDto.CardsAmount,
                ReleaseDate = expansionDto.ReleaseDate,
                Abbreviation = expansionDto.Abbreviation
            };

            await _expansionRepository.CreateAsync(expansionToCreate);
            await _expansionRepository.SaveChangesAsync();

            return expansionToCreate.Id;
        }
    }
}
