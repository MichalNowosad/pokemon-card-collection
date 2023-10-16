using PokemonCardCollection.Domain.Enums;

namespace PokemonCardCollection.Domain.Entities
{
    public class TrainerCard : Card
    {
        public TrainerCard()
        {
            CardType = CardType.Trainer;
        }

        public string EffectDescription { get; set; } = string.Empty;
    }
}
