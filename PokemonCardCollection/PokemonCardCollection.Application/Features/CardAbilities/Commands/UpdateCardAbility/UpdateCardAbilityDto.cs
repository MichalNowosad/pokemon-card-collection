namespace PokemonCardCollection.Application.Features.CardAbilities.Commands.UpdateCardAbility
{
    public class UpdateCardAbilityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
