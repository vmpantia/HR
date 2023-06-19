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

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var response = _employee.GetEmployees();
                if(response == null) 
                    return NotFound();

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}