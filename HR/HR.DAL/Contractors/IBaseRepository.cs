using System.Linq.Expressions;

namespace HR.DAL.Contractors
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        TEntity GetOne(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}