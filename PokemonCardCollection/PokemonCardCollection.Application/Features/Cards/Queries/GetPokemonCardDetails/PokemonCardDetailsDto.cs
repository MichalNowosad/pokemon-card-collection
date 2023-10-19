using PokemonCardCollection.Application.Models.File;
using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetPokemonCardDetails
{
    public class PokemonCardDetailsDto : FileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public int HealthPoints { get; set; }
        public string Description { get; set; } = string.Empty;
        public EnergyType EnergyType { get; set; }
        public CardRarity Rarity { get; set; }
        public string ExpansionName { get; set; } = string.Empty;
        public string IllustratorName { get; set; } = string.Empty;
        public PokemonCardAbilityDto? Ability { get; set; }
        public IEnumerable<PokemonCardAttackDto>? Attacks { get; set; }
    }
}
