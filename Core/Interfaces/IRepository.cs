
namespace Core.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<List<T>> Get();
    public Task<T?> GetById(int id);
    public Task Put(T entity);
    public Task<List<T>> GetByPage(int pageNumber, int pageSize);
}