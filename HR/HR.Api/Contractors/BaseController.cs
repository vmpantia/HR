using HR.BAL.Models.Filter;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Contractors
{
    public class BaseController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        public BaseController(IConfiguration configuration) => _configuration = configuration;

        protected IActionResult OkPagedResult<TDto>(FilterRequest filter, IEnumerable<TDto> pagedItems, int totalItems, int totalPages)
        {
            return Ok(new FilterResponse<TDto>()
            {
                Data = pagedItems,
                Pagination = new Pagination
                {
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                },
                Links = new PageLinkBuilder(_configuration["Web:BaseApiUrl"],
                                            ControllerContext.ActionDescriptor.ControllerName,
                                            totalPages,
                                            filter)
            });
        }
    }
}
