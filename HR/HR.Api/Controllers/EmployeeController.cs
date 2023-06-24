using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.DataAccess.Entities;
using HR.DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly BaseService<Employee> _employee;
        public EmployeeController(BaseService<Employee> employee) => _employee = employee;

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var response = _employee.GetAll<EmployeeDTO>();
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
                var response = _employee.GetByID<EmployeeDTO>(internalID);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSaveEmployee")]
        public async Task<IActionResult> PostSaveEmployeeAsync(SaveRequest<EmployeeDTO> request)
        {
            try
            {
                await _employee.SaveAsync(request);
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
                await _employee.DeleteAsync(request);
                return Ok(Message.SUCCESS_DELETING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}