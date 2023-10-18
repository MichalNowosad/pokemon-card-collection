using MediatR;

namespace PokemonCardCollection.Application.Features.Expansions.Commands.CreateExpansion
{
    public class CreateExpansionCommand : IRequest<CreateExpansionCommandResponse>
    {
        public CreateExpansionDto Expansion { get; set; } = new CreateExpansionDto();
    }
}
