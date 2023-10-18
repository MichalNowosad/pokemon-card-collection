using MediatR;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommand : IRequest<UpdateExpansionCommandResponse>
    {
        public UpdateExpansionDto Expansion { get; set; } = new UpdateExpansionDto();
    }
}
