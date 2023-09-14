using HR.Common.Constants;
using HR.Common.Exceptions;
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

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return _table.Where(expression)
                         .AsNoTracking();
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> expression)
        {
            var result = _table.Where(expression).FirstOrDefault();

            if (result == null)
                throw new NotFoundException(Message.ERROR_NOT_FOUND_IN_DB);

            return result;
        }

        public void Add(TEntity entity)
        {
            _table.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
    }
}
