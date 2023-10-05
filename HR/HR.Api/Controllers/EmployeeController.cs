using HR.Api.Contractors;
using HR.BAL.Models.Filter;
using HR.BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly EmployeeService _employee;

        public EmployeeController(IConfiguration configuration, EmployeeService employee) : base(configuration) 
        { 
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetEmployees([FromQuery]FilterRequest request)
        {
            var employees = _employee.GetEmployees(request, out int totalItems, out int totalPages);
            return OkPagedResult(request, employees, totalItems, totalPages);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetEmployee(Guid employeeId)
        {
            var employee = _employee.GetEmployee(employeeId);
            return Ok(employee);
        }
    }
}
