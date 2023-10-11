using System.Linq.Expressions;

namespace BookApplication.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveFill(IEnumerable<T> entities);


    }
}
