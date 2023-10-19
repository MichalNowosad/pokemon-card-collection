using MediatR;
using Microsoft.AspNetCore.Http;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionCommand : IRequest<CreateExpansionCommandResponse>
    {
        public CreateExpansionCommand(CreateExpansionDto expansion, IFormFile expansionImage)
        {
            Expansion = expansion;
            ExpansionImage = expansionImage;
        }

        public CreateExpansionDto Expansion { get; set; }
        public IFormFile ExpansionImage { get; set; }
    }
}
