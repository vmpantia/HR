using HR.Api.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Request;
using HR.BAL.Services;
using HR.Common.Constants;
using HR.DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly EmployeeService _employee;
        public EmployeeController(EmployeeService employee, ILogger<EmployeeController> logger) : base(logger) 
        {
            _employee = employee;
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var response = _employee.GetFullInfo();
                return OkResult(response);
            }
            catch (CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpGet("GetEmployeeByID")]
        public IActionResult GetEmployeeByID(Guid internalID)
        {
            try
            {
                var response = _employee.GetByID<EmployeeDTO>(internalID);
                return OkResult(response);
            }
            catch (CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpPost("PostSaveEmployee")]
        public async Task<IActionResult> PostSaveEmployeeAsync(SaveRequest<EmployeeDTO> request)
        {
            try
            {
                await _employee.SaveAsync(request);
                return OkResult(string.Format(Message.SUCCESS_SAVING, HRObject.OBJECT_EMPLOYEE));
            }
            catch(CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpPost("PostDeleteEmployee")]
        public async Task<IActionResult> PostDeleteEmployeeAsync(DeleteByIDRequest request)
        {
            try
            {
                await _employee.DeleteAsync(request);
                return OkResult(string.Format(Message.SUCCESS_DELETING, HRObject.OBJECT_EMPLOYEE));
            }
            catch(CustomException ex)
            {
                return ErrorResult(ex);
            }
        }
    }
}