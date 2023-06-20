using Azure.Core;
using HR.BAL.Contractors;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _position;

        public PositionController(IPositionService position) => _position = position;

        [HttpGet("GetPositions")]
        public IActionResult GetPositions()
        {
            try
            {
                var response = _position.GetPositions();
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
                var response = _position.GetPositionByID(internalID);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSavePosition")]
        public async Task<IActionResult> PostSavePositionAsync(SavePositionRequest request)
        {
            try
            {
                await _position.SavePositionAsync(request);
                return Ok(Message.SUCCESS_SAVING_EMPLOYEE);
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
                await _position.DeletePositionAsync(request);
                return Ok(Message.SUCCESS_DELETING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}