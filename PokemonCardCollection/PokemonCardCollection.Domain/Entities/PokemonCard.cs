using PokemonCardCollection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
