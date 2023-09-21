using HR.BAL.Models.Filter;

namespace HR.Api.Helpers
{
    public class PaginationHelper
    {
        private readonly UrlHelper _url;
        public PaginationHelper(UrlHelper url) => _url = url;

        public FilterResponse<IEnumerable<TDto>> GetPaged<TDto>(string controller, FilterRequest filter, IEnumerable<TDto> items)
        {

            var totalItems = items.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)filter.PageSize);

            var pagedData = items.Skip((filter.PageNumber - 1) * filter.PageSize)
                                 .Take(filter.PageSize)
                                 .ToList();

            return new FilterResponse<IEnumerable<TDto>>()
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
                    Current = _url.BuilUrl(controller, filter.PageNumber, filter.PageSize, filter.Filter, filter.Order),
                    First = _url.BuilUrl(controller, 1, filter.PageSize, filter.Filter, filter.Order),
                    Last = _url.BuilUrl(controller, totalPages, filter.PageSize, filter.Filter, filter.Order),
                    Next = _url.BuilUrl(controller, filter.PageNumber == totalPages ? totalPages : filter.PageNumber + 1, filter.PageSize, filter.Filter, filter.Order),
                    Previous = _url.BuilUrl(controller, filter.PageNumber == 1 ? 1 : filter.PageNumber - 1, filter.PageSize, filter.Filter, filter.Order),
                }
            };
        }
    }
}
