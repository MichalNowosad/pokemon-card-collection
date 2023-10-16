namespace PokemonCardCollection.Application.Features.CardAttacks.Commands.UpdateCardAttack
{
    public class UpdateCardAttackDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Power { get; set; }
    }
}
