using FinalProjectLibrary.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalProjectLibrary.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly WarmFinalProjectContext context;
        public GenericRepository(WarmFinalProjectContext context)
        {
            this.context = context;
        }
        public async Task Add(T entity)
        {
            context.Set<T>().AddAsync(entity);
        }
        public async Task AddRange(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(string id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
