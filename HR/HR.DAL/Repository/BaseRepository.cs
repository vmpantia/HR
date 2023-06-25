using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using HR.DAL.Exceptions;
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

        public void Add(TEntity entity)
        {
            _table.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var res = GetByID(id);
            if (res != null)
                _table.Remove(res);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteByExpression(Expression<Func<TEntity, bool>> expression)
        {
            var result = GetByExpression(expression);
            foreach(var item in result)
                Delete(item);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _table.AsNoTracking();
        }

        public TEntity GetByID(Guid id)
        {
            var result = _table.Find(id);
            if (result == null)
                throw new CustomException(string.Format(Message.ERROR_NO_RECORD_FOUND_BY_ID, id));

            return result;
        }

        public IEnumerable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return _table.Where(expression);
        }
    }
}
