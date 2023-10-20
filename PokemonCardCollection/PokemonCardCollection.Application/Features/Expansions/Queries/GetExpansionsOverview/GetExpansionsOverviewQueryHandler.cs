using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionsOverview
{
    public class GetExpansionsOverviewQueryHandler : IRequestHandler<GetExpansionsOverviewQuery, GetExpansionsOverviewQueryResponse>
    {
        private readonly IExpansionRepository _expansionRepository;

        public GetExpansionsOverviewQueryHandler(IExpansionRepository expansionRepository)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
        }

        public async Task<GetExpansionsOverviewQueryResponse> Handle(GetExpansionsOverviewQuery request, CancellationToken cancellationToken)
        {
            var expansions = await _expansionRepository.GetAllAsync()
                .Select(e => new ExpansionOverviewDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    ReleaseDate = e.ReleaseDate
                }).ToListAsync(cancellationToken: cancellationToken);

            return new GetExpansionsOverviewQueryResponse(expansions);
        }
    }
}
