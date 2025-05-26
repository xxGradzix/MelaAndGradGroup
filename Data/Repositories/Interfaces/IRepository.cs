
namespace Data.Repositories.Interfaces
{
    public interface IRepository<T, ID> where T : class
    {
        T FindByID(ID id);
        T Save(T entity);
        bool Delete(T entity);
        bool Delete(ID id);
        T Update(T entity);
        List<T> FindAll();

    }
    
}
    
