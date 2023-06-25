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
    public class PositionController : BaseController
    {
        private readonly PositionService _position;
        public PositionController(PositionService position, ILogger<PositionController> logger) : base(logger)
        {
            _position = position;
        }

        [HttpGet("GetPositions")]
        public IActionResult GetPositions()
        {
            try
            {
                var response = _position.GetAll();
                return OkResult(response);
            }
            catch (CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpGet("GetPositionByID")]
        public IActionResult GetPositionByID(Guid internalID)
        {
            try
            {
                var response = _position.GetByID(internalID);
                return OkResult(response);
            }
            catch (CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpPost("PostSavePosition")]
        public async Task<IActionResult> PostSavePositionAsync(SaveRequest<PositionDTO> request)
        {
            try
            {
                await _position.SaveAsync(request);
                return OkResult(string.Format(Message.SUCCESS_SAVING, HRObject.OBJECT_POSITION));
            }
            catch(CustomException ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpPost("PostDeletePosition")]
        public async Task<IActionResult> PostDeletePositionAsync(DeleteByIDRequest request)
        {
            try
            {
                await _position.DeleteAsync(request);
                return OkResult(string.Format(Message.SUCCESS_DELETING, HRObject.OBJECT_POSITION));
            }
            catch(CustomException ex)
            {
                return ErrorResult(ex);
            }
        }
    }
}