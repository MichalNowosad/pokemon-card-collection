using MediatR;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreatePokemonCard
{
    public class CreatePokemonCardCommand : IRequest<Guid>
    {
        public CreatePokemonCardDto? PokemonCard { get; set; }
    }
}
