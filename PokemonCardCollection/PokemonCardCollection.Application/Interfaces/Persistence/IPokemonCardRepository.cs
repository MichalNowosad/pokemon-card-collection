using PokemonCardCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardCollection.Application.Interfaces.Persistence
{
    public interface IPokemonCardRepository : IRepositoryBase<PokemonCard>
    {
        IQueryable<PokemonCard> GetByExpansionId(Guid expansionId);
    }
}
