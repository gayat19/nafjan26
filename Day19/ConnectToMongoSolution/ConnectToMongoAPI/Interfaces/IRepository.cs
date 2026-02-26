namespace ConnectToMongoAPI.Interfaces
{
    public interface IRepository<K,T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(K id);
        Task<T> CreateAsync(T entity);
        
    }
}
