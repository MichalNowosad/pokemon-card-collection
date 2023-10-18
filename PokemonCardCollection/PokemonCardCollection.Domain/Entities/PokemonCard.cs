using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Domain.Entities
{
    public class PokemonCard : Card
    {
        public PokemonCard()
        {
            CardType = CardType.Pokemon;
        }

        public int HealthPoints { get; set; }
        public string PokemonDescription { get; set; } = string.Empty;
        public EnergyType EnergyType { get; set; }
        public Guid? AbilityId { get; set; }
        public CardAbility? Ability { get; set; }
        public ICollection<CardAttack> Attacks { get; set; } = new List<CardAttack>();
    }
}
