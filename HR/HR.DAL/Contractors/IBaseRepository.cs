using System.Linq.Expressions;

namespace HR.DAL.Contractors
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
        void DeleteByExpression(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(Guid id);
        IEnumerable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
    }
}