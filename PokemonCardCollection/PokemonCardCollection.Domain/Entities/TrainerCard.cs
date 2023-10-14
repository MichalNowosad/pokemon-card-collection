using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Domain.Entities
{
    public class TrainerCard : Card
    {
        public string EffectDescription { get; set; } = string.Empty;
    }
}
