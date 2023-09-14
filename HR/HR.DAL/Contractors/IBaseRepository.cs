using System.Linq.Expressions;

namespace HR.DAL.Contractors
{
    public interface IBaseRepository<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        TEntity GetOne(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity entity);
    }
}