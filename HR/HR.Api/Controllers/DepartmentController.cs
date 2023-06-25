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
    public class DepartmentController : BaseController
    {
        private readonly DepartmentService _department;

        public DepartmentController(DepartmentService service, ILogger<DepartmentController> logger) : base(logger)
        {
            _department = service;
        }

        [HttpGet("GetDepartments")]
        public IActionResult GetDepartments()
        {
            try
            {
                var response = _department.GetAll();
                return OkResult(response);
            }
            catch (CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpGet("GetDepartmentByID")]
        public IActionResult GetDepartmentByID(Guid internalID)
        {
            try
            {
                var response = _department.GetByID(internalID);
                return OkResult(response);
            }
            catch (CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpPost("PostSaveDepartment")]
        public async Task<IActionResult> PostSaveDepartmentAsync(SaveRequest<DepartmentDTO> request)
        { 
            try
            {
                await _department.SaveAsync(request);
                return OkResult(string.Format(Message.SUCCESS_SAVING, HRObject.OBJECT_DEPARTMENT));
            }
            catch(CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpPost("PostDeleteDepartment")]
        public async Task<IActionResult> PostDeleteDepartmentAsync(DeleteByIDRequest request)
        {
            try
            {
                await _department.DeleteAsync(request);
                return OkResult(string.Format(Message.SUCCESS_DELETING, HRObject.OBJECT_DEPARTMENT));
            }
            catch(CustomException ex)
            {
                return ErrorResult(ex);
            }
        }
    }
}