using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using HR.DAL.DataAccess.Entities;
using HR.DAL.Exceptions;

namespace HR.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext _db;
        public UnitOfWork(HRDbContext context) => _db = context;

        public IBaseRepository<T> GetRepository<T>() where T : class
        {
            return new BaseRepository<T>(_db);
        }

        public async Task SaveChangesAsync()
        {
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new CustomException(Message.ERROR_SAVING);
        }
    }
}
