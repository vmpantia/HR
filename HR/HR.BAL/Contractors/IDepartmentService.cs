using HR.BAL.Models;
using HR.BAL.Models.Request;

namespace HR.BAL.Contractors
{
    public interface IDepartmentService
    {
        Task DeleteDepartmentAsync(DeleteByIDRequest request);
        DepartmentDTO GetDepartmentByID(Guid internalID);
        IEnumerable<DepartmentDTO> GetDepartments();
        Task SaveDepartmentAsync(SaveDepartmentRequest request);
    }
}