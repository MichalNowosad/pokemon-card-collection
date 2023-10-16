namespace PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails
{
    public class PokemonCardAttackDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Power { get; set; }
    }
}
