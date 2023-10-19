using PokemonCardCollection.Application.Models.File;
using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Application.Features.Cards.Queries.GetTrainerCardDetails
{
    public class TrainerCardDetailsDto : FileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Description { get; set; } = string.Empty;
        public CardRarity Rarity { get; set; }
        public string ExpansionName { get; set; } = string.Empty;
        public string IllustratorName { get; set; } = string.Empty;

    }
}
