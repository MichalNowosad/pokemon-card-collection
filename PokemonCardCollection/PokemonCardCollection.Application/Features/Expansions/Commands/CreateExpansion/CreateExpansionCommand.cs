using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionCommand : IRequest<CreateExpansionCommandResponse>
    {
        public CreateExpansionCommand(IFormCollection form)
        {
            Expansion = JsonConvert.DeserializeObject<CreateExpansionDto>(form["expansion"].ToString()) ?? new CreateExpansionDto();
            ExpansionImage = form.Files[0];
        }

        public CreateExpansionDto Expansion { get; set; }
        public IFormFile ExpansionImage { get; set; }
    }
}
