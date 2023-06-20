using HR.BAL.Models;
using HR.BAL.Models.Request;

namespace HR.BAL.Contractors
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployeeByID(Guid internalID);
        Task SaveEmployeeAsync(SaveEmployeeRequest request);
        Task DeleteEmployeeAsync(DeleteEmployeeRequest request);
    }
}