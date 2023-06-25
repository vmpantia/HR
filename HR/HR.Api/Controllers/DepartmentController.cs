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
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _department;
        public DepartmentController(DepartmentService department) => _department = department;

        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments()
        {
            try
            {
                var response = _department.GetAll<DepartmentDTO>();
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
                var response = _department.GetByID<DepartmentDTO>(internalID);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSaveDepartment")]
        public async Task<IActionResult> PostSaveDepartmentAsync(SaveRequest<DepartmentDTO> request)
        { 
            try
            {
                await _department.SaveAsync(request);
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
                await _department.DeleteAsync(request);
                return Ok(Message.SUCCESS_DELETING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}