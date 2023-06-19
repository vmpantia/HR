using HR.DAL.DataAccess.Entities;

namespace HR.DAL.Contractors
{
    public interface IUnitOfWork
    {
        IBaseRepository<Employee> EmployeeRepository { get; }

        Task SaveChangesAsync();
    }
}