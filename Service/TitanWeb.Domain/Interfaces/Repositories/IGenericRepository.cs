using System.Linq.Expressions;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
        Task Add(T entity);
    }
}
