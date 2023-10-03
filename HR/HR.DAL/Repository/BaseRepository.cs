using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.DAL.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _table;

        public BaseRepository(HRDbContext context)
        {
            _db = context;
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() =>
            _table.AsNoTracking();

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression) =>
            _table.Where(expression).AsNoTracking();

        public void Add(TEntity entity) => 
            _table.Add(entity);

        public void Update(TEntity entity) =>
            _table.Update(entity);

        public void Delete(TEntity entity) =>
            _table.Remove(entity);
    }
}
