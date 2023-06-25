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
    public class PositionController : ControllerBase
    {
        private readonly PositionService _position;
        public PositionController(PositionService position) => _position = position;

        [HttpGet("GetPositions")]
        public IActionResult GetPositions()
        {
            try
            {
                var response = _position.GetAll<PositionDTO>();
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPositionByID")]
        public IActionResult GetPositionByID(Guid internalID)
        {
            try
            {
                var response = _position.GetByID<PositionDTO>(internalID);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSavePosition")]
        public async Task<IActionResult> PostSavePositionAsync(SaveRequest<PositionDTO> request)
        {
            try
            {
                await _position.SaveAsync(request);
                return Ok(string.Format(Message.SUCCESS_SAVING, HRObject.OBJECT_POSITION));
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostDeletePosition")]
        public async Task<IActionResult> PostDeletePositionAsync(DeleteByIDRequest request)
        {
            try
            {
                await _position.DeleteAsync(request);
                return Ok(string.Format(Message.SUCCESS_DELETING, HRObject.OBJECT_POSITION));
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}