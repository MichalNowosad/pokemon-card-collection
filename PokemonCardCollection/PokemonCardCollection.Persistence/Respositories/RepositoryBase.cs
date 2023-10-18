using Microsoft.EntityFrameworkCore;
using PokemonCardCollection.Application.Interfaces.Persistence;

namespace PokemonCardCollection.Persistence.Respositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly PokemonCardCollectionDbContext _dbContext;

        public RepositoryBase(PokemonCardCollectionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);

            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAllAsync()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
