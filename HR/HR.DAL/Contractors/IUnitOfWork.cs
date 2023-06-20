using HR.DAL.DataAccess.Entities;

namespace HR.DAL.Contractors
{
    public interface IUnitOfWork
    {
        IBaseRepository<Employee> EmployeeRepository { get; }
        IBaseRepository<Department> DepartmentRepository { get; }
        IBaseRepository<Position> PositionRepository { get; }
        IBaseRepository<Contact> ContactRepository { get; }
        IBaseRepository<Address> AddressRepository { get; }
        Task SaveChangesAsync();
    }
}