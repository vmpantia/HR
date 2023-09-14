using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess;

namespace HR.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext _db;
        public UnitOfWork(HRDbContext context) => _db = context;

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new BaseRepository<TEntity>(_db);
        }

        public async Task SaveChangesAsync()
        {
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new Exception(Message.ERROR_SAVING);
        }
    }
}
