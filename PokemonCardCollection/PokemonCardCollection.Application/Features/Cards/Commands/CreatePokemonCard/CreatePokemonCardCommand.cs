using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard
{
    public class CreatePokemonCardCommand : IRequest<CreatePokemonCardCommandResponse>
    {
        public CreatePokemonCardDto PokemonCard { get; set; } = new CreatePokemonCardDto();
    }
}
