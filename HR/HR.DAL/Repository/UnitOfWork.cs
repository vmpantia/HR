using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess;

namespace HR.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext _db;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public UnitOfWork(HRDbContext context) => _db = context;

        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IBaseRepository<TEntity>;

            var repository = new BaseRepository<TEntity>(_db);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public async Task SaveChangesAsync()
        {
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new Exception(Message.ERROR_SAVING);
        }
    }
}
