namespace PokemonCardCollection.Application.Interfaces.Persistence
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAllAsync();
        Task<T?> GetAsync(Guid id);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(Guid id);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
