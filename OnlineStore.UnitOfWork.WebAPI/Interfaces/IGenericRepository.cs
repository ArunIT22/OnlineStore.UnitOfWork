namespace OnlineStore.UnitOfWork.WebAPI.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<bool> AddNewAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(T entity);
    }
}
