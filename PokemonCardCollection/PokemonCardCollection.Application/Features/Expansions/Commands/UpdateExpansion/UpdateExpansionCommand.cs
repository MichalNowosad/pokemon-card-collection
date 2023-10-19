using MediatR;
using Microsoft.AspNetCore.Http;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommand : IRequest<UpdateExpansionCommandResponse>
    {
        public UpdateExpansionCommand(UpdateExpansionDto expansion, IFormFile expansionImage)
        {
            Expansion = expansion;
            ExpansionImage = expansionImage;
        }

        public UpdateExpansionDto Expansion { get; set; } = new UpdateExpansionDto();
        public IFormFile ExpansionImage { get; set; }
    }
}
