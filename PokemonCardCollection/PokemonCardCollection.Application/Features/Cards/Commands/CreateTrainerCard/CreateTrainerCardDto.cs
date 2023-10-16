using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Application.Features.Cards.Commands.CreateTrainerCard
{
    public class CreateTrainerCardDto
    {
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public string EffectDescription { get; set; } = string.Empty;
        public CardRarity Rarity { get; set; }
        public Guid ExpansionId { get; set; }
        public Guid IllustratorId { get; set; }
    }
}
