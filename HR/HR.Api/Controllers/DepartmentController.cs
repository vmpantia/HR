using HR.BAL.Contractors;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _department;
        public DepartmentController(IDepartmentService department) => _department = department;

        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments()
        {
            try
            {
                var response = _department.GetDepartments();
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDepartmentByID")]
        public IActionResult GetDepartmentByID(Guid internalID)
        {
            try
            {
                var response = _department.GetDepartmentByID(internalID);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSaveDepartment")]
        public async Task<IActionResult> PostSaveDepartmentAsync(SaveDepartmentRequest request)
        {
            try
            {
                await _department.SaveDepartmentAsync(request);
                return Ok(Message.SUCCESS_SAVING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostDeleteDepartment")]
        public async Task<IActionResult> PostDeleteDepartmentAsync(DeleteByIDRequest request)
        {
            try
            {
                await _department.DeleteDepartmentAsync(request);
                return Ok(Message.SUCCESS_DELETING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}