using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using HR.DAL.DataAccess.Entities;

namespace HR.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext _db;
        private IBaseRepository<Employee> _empRep;
        public UnitOfWork(HRDbContext context) => _db = context;

        public IBaseRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_empRep == null)
                    _empRep = new BaseRepository<Employee>(_db);

                return _empRep;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
