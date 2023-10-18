using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardCommand : IRequest<UpdatePokemonCardCommandResponse>
    {
        public UpdatePokemonCardDto PokemonCard { get; set; } = new UpdatePokemonCardDto();
    }
}
