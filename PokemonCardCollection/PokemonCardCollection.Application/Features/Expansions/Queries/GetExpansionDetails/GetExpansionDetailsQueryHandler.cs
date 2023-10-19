using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Constants;
using PokemonCardCollection.Application.Interfaces.Infrastructure;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Application.Features.Expansions.Queries.GetExpansionDetails
{
    public class GetExpansionDetailsQueryHandler : IRequestHandler<GetExpansionDetailsQuery, ExpansionDetailsDto>
    {
        private readonly IExpansionRepository _expansionRepository;
        private readonly IFileService _fileService;

        public GetExpansionDetailsQueryHandler(IExpansionRepository expansionRepository,
            IFileService fileService)
        {
            _expansionRepository = expansionRepository ?? throw new ArgumentNullException(nameof(expansionRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));        }

        public async Task<ExpansionDetailsDto> Handle(GetExpansionDetailsQuery request, CancellationToken cancellationToken)
        {
            var allExpansions = _expansionRepository.GetAllAsync();

            var expansion = await allExpansions.Select(e => new ExpansionDetailsDto
            {
                Id = e.Id,
                Name = e.Name,
                CardsAmount = e.CardsAmount,
                ReleaseDate = e.ReleaseDate,
                Abbreviation = e.Abbreviation,
                FileName = e.FileName
            }).FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

            expansion.FileStream = await _fileService.GetFileStream(expansion.FileName, FileConstants.ExpansionFolderName);

            return expansion;
        }
    }
}
