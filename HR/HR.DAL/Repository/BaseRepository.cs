using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.DAL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;

        public BaseRepository(HRDbContext context)
        {
            _db = context;
            _table = context.Set<T>();
        }

        public void Add(T entity)
        {
            _table.Add(entity);
        }

        public void Update(Guid id, T entity)
        {
            var res = GetByID(id);
            if (res != null)
            {
                _table.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(Guid id)
        {
            var res = GetByID(id);
            if (res != null)
                _table.Remove(res);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.AsNoTracking();
        }

        public T GetByID(Guid id)
        {
            var result = _table.Find(id);
            if (result == null)
                throw new Exception(string.Format(ErrorMessage.ERROR_NO_RECORD_FOUND_BY_ID, id));

            return result;
        }

        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression);
        }
    }
}
