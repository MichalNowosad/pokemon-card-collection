using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails
{
    public class GetExpansionDetailsQueryHandler : IRequestHandler<GetExpansionDetailsQuery, ExpansionDetailsDto>
    {
        private readonly IExpansionRepository _expansionRepository;

        public GetExpansionDetailsQueryHandler(IExpansionRepository expansionRepository)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
        }

        public async Task<ExpansionDetailsDto> Handle(GetExpansionDetailsQuery request, CancellationToken cancellationToken)
        {
            var allExpansions = _expansionRepository.GetAllAsync();

            var expansion = await allExpansions.Select(e => new ExpansionDetailsDto
            {
                Id = e.Id,
                Name = e.Name,
                CardsAmount = e.CardsAmount,
                ReleaseDate = e.ReleaseDate,
                Abbreviation = e.Abbreviation
            }).FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

            return expansion;
        }
    }
}
