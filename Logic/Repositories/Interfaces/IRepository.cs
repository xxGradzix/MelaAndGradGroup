
namespace Logic.Repositories.Interfaces
{
    public interface IRepository<T, ID> where T : class
    {
        Task<T> FindByID(ID id);
        Task<T> Save(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<List<T>> FindAll();

    }
    
}
    
