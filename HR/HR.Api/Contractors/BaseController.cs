using HR.Api.Helpers;
using HR.BAL.Models.Filter;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Contractors
{
    public class BaseController : ControllerBase
    {
        private readonly UrlHelper _url;
        public BaseController(UrlHelper url)
        {
            _url = url;
        }

        protected IActionResult OkPagedResult<TDto>(IEnumerable<TDto> items, FilterRequest filter)
        {
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var totalItems = items.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)filter.PageSize);

            var pagedData = items.Skip((filter.PageNumber - 1) * filter.PageSize)
                                 .Take(filter.PageSize)
                                 .ToList();

            return Ok(new FilterResponse<TDto>()
            {
                Data = pagedData,
                Pagination = new Pagination
                {
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                },
                Links = new LinkBuilder
                {
                    Current = _url.BuilUrl(controllerName, filter.PageNumber, filter.PageSize, filter.Filter, filter.Order),
                    First = _url.BuilUrl(controllerName, 1, filter.PageSize, filter.Filter, filter.Order),
                    Last = _url.BuilUrl(controllerName, totalPages, filter.PageSize, filter.Filter, filter.Order),
                    Next = _url.BuilUrl(controllerName, filter.PageNumber == totalPages ? totalPages : filter.PageNumber + 1, filter.PageSize, filter.Filter, filter.Order),
                    Previous = _url.BuilUrl(controllerName, filter.PageNumber == 1 ? 1 : filter.PageNumber - 1, filter.PageSize, filter.Filter, filter.Order),
                }
            });
        }
    }
}
