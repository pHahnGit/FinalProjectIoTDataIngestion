using System.Linq.Expressions;

namespace FinalProjectLibrary.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}