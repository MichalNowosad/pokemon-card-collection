using PokemonCardCollection.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Domain.Entities
{
    public class Illustrator : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
