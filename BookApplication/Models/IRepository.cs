using System.Linq.Expressions;

namespace BookApplication.Models
{
    public interface IRepository<T> where T :class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filtre);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
