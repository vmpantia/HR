using HR.BAL.Contractors;
using HR.BAL.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;

        public EmployeeController(IEmployeeService employee) => _employee = employee;

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            var response = _employee.GetEmployees();
            return Ok(response);
        }

        [HttpGet("GetEmployeeByID")]
        public IActionResult GetEmployeeByID(Guid internalID)
        {
            var response = _employee.GetEmployeeByID(internalID);
            return Ok(response);
        }

        [HttpPost("SaveEmployee")]
        public async Task<IActionResult> SaveEmployeeAsync(SaveEmployeeRequest request)
        {
            await _employee.SaveEmployeeAsync(request);
            return Ok("Employee has been saved successfully.");
        }

        [HttpPost("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployeeAsync(DeleteEmployeeRequest request)
        {
            await _employee.DeleteEmployeeAsync(request);
            return Ok("Employee has been deleted successfully.");
        }
    }
}