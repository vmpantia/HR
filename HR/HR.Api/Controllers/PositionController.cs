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
    public class PositionController : ControllerBase
    {
        private readonly BaseService<Position> _position;
        public PositionController(BaseService<Position> position) => _position = position;

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
                await _position.DeleteAsync(request);
                return Ok(Message.SUCCESS_DELETING_EMPLOYEE);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}