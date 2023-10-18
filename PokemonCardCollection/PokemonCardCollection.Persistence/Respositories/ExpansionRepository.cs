using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Respositories
{
    public class ExpansionRepository : RepositoryBase<Expansion>, IExpansionRepository
    {
        public ExpansionRepository(PokemonCardCollectionDbContext dbContext) : base(dbContext) { }
    }
}
