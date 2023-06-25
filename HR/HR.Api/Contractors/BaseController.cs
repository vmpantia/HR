using HR.BAL.Models.Response;
using HR.DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Contractors
{
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected IActionResult OkResult(object data)
        {
            var customMessage = "Your request has been processed successfully!";
            _logger.LogInformation(customMessage);
            return Ok(new RequestResponse { Message = customMessage, Data = data });
        }

        protected IActionResult OkResult(string message)
        {
            _logger.LogInformation(message);
            return Ok(new RequestResponse { Message = message });
        }

        protected IActionResult OkResult(string message, object data)
        {
            _logger.LogInformation(message);
            return Ok(new RequestResponse { Message = message, Data = data });
        }

        protected IActionResult ErrorResult(CustomException exception)
        {
            _logger.LogError(exception.StackTrace);
            return BadRequest(new RequestResponse { Message = exception.Message, Data = exception });
        }
    }
}
