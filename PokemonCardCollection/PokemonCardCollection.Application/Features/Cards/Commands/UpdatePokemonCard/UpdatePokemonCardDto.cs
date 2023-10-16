using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdatePokemonCard
{
    public class UpdatePokemonCardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public CardRarity Rarity { get; set; }
        public Guid ExpansionId { get; set; }
        public Guid IllustratorId { get; set; }
        public int HealthPoints { get; set; }
        public string PokemonDescription { get; set; } = string.Empty;
        public EnergyType EnergyType { get; set; }
        public Guid AbilityId { get; set; }
        public IEnumerable<Guid>? AttackIds { get; set; }
    }
}
