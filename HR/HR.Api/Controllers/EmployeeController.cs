using HR.BAL.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;

        public EmployeeController(IEmployeeService employee) => _employee = employee;

        [HttpGet]
        public IActionResult GetEmployees1()
        {
            return Ok(_employee.GetEmployees1());
        }
        [HttpGet]
        public IActionResult GetEmployees2()
        {
            return Ok(_employee.GetEmployees2());
        }
    }
}