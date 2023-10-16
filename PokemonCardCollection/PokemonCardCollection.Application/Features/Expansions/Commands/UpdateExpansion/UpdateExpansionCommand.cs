using MediatR;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.UpdateExpansion
{
    public class UpdateExpansionCommand : IRequest
    {
        public UpdateExpansionDto? Expansion { get; set; }
    }
}
