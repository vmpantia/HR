using System.Linq.Expressions;

namespace HR.DAL.Contractors
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> expression);
        Task<T> GetByIDAsync(Guid id);
        void Update(T entity);
    }
}