using PokemonCardCollection.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Features.Cards.Commands.UpdateTrainerCard
{
    public class UpdateTrainerCardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public string EffectDescription { get; set; } = string.Empty;
        public CardRarity Rarity { get; set; }
        public Guid ExpansionId { get; set; }
        public Guid IllustratorId { get; set; }
    }
}
