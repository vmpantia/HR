using System.Linq.Expressions;

namespace HR.DAL.Contractors
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        IEnumerable<T> GetAll();
        T GetByID(Guid id);
        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> expression);
    }
}