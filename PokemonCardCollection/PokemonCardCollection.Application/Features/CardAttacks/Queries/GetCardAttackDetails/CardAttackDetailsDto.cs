namespace PokemonCardCollection.Application.Features.CardAttacks.Queries.GetCardAttackDetails
{
    public class CardAttackDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Power { get; set; }
    }
}
