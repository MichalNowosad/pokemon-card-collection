using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionsOverview
{
    public class GetExpansionsOverviewQueryHandler : IRequestHandler<GetExpansionsOverviewQuery, IEnumerable<ExpansionOverviewDto>>
    {
        private readonly IExpansionRepository _expansionRepository;

        public GetExpansionsOverviewQueryHandler(IExpansionRepository expansionRepository)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
        }

        public async Task<IEnumerable<ExpansionOverviewDto>> Handle(GetExpansionsOverviewQuery request, CancellationToken cancellationToken)
        {
            var expansions = _expansionRepository.GetAllAsync();

            return await expansions.Select(e => new ExpansionOverviewDto
            {
                Id = e.Id,
                Name = e.Name,
                ReleaseDate = e.ReleaseDate
            }).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
