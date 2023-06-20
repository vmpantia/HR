using HR.BAL.Contractors;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Exceptions;
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
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEmployeeByID")]
        public IActionResult GetEmployeeByID(Guid internalID)
        {
            try
            {
                var response = _employee.GetEmployeeByID(internalID);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSaveEmployee")]
        public async Task<IActionResult> PostSaveEmployeeAsync(SaveEmployeeRequest request)
        {
            try
            {
                await _employee.SaveEmployeeAsync(request);
                return Ok(Message.SUCCESS_SAVING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostDeleteEmployee")]
        public async Task<IActionResult> PostDeleteEmployeeAsync(DeleteByIDRequest request)
        {
            try
            {
                await _employee.DeleteEmployeeAsync(request);
                return Ok(Message.SUCCESS_DELETING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}