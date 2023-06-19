using HR.BAL.Models;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Contractors
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployees1();
        IEnumerable<Employee> GetEmployees2();
    }
}