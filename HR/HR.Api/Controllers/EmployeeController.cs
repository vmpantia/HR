using HR.BAL.Models;
using HR.BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeService _employee;
        public EmployeeController(EmployeeService employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employee.GetAll<EmployeeDto>();

            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetOne(Guid employeeId)
        {
            var result = _employee.GetOne<EmployeeDto>(data => data.Id == employeeId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] SaveEmployeeDto dto)
        {
            await _employee.SaveAsync(dto);

            return Ok("Employee added sucessfully.");
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> PutAsync(Guid employeeId, [FromForm] SaveEmployeeDto dto)
        {
            await _employee.SaveAsync(dto, employeeId);

            return Ok("Employee updated sucessfully.");
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteAsync(Guid employeeId)
        {
            await _employee.DeleteAsync(employeeId);

            return Ok("Employee deleted sucessfully.");
        }
    }
}
