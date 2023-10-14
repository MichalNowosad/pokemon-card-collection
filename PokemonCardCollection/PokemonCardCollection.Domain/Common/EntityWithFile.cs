using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Domain.Common
{
    public class EntityWithFile : BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string DisplayFileName { get; set; } = string.Empty;
    }
}
