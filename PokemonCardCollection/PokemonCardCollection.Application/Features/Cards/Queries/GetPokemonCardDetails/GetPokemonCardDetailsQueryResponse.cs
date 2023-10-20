using PokemonCardCollection.Application.Responses;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails
{
    public class GetPokemonCardDetailsQueryResponse : ResponseBase
    {
        public GetPokemonCardDetailsQueryResponse(PokemonCardDetailsDto pokemonCard) : base()
        {
            PokemonCard = pokemonCard;
        }

        public PokemonCardDetailsDto PokemonCard { get; set; }
    }
}
