using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommand : IRequest<UpdateExpansionCommandResponse>
    {
        public UpdateExpansionCommand(IFormCollection form)
        {
            Expansion = JsonConvert.DeserializeObject<UpdateExpansionDto>(form["expansion"].ToString()) ?? new UpdateExpansionDto();
            ExpansionImage = form.Files[0];
        }

        public UpdateExpansionDto Expansion { get; set; }
        public IFormFile ExpansionImage { get; set; }
    }
}
