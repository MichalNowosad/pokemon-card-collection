namespace PokemonCardCollection.Application.Interfaces.Persistence
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<Guid> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(T entity);
    }
}
