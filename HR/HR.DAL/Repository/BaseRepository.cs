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

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.AsNoTracking();
        }

        public async Task<T> GetByIDAsync(Guid id)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
                throw new Exception(string.Format(ErrorMessage.NO_RECORD_FOUND_BY_ID, id));

            return result;
        }

        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression);
        }
    }
}
