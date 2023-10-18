using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;
using PokemonCardCollection.Domain.Entities;

namespace PokemonCardCollection.Persistence.Respositories
{
    public class TrainerCardRepository : RepositoryBase<TrainerCard>, ITrainerCardRepository
    {
        private readonly DbSet<TrainerCard> _trainerCards;

        public TrainerCardRepository(PokemonCardCollectionDbContext dbContext) : base(dbContext)
        {
            _trainerCards = dbContext.Set<TrainerCard>();
        }

        public IQueryable<TrainerCard> GetByExpansionId(Guid expansionId)
        {
            return _trainerCards.Where(c => c.ExpansionId == expansionId);
        }
    }
}
