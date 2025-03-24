namespace MelaAndGradGroup.onlineShopProgram;

public interface Repository<T, ID> where T : class
{
    
    Task<T> findByID(ID id);
    Task<T> save(T entity);
    Task delete(T entity);
    Task update(T entity);
    Task<List<T>> findAll();

}