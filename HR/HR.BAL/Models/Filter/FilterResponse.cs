namespace HR.BAL.Models.Filter
{
    public class FilterResponse<TDto>
    {
        public IEnumerable<TDto> Data { get; set; }
        public Pagination Pagination { get; set; }
        public PageLinkBuilder Links { get; set; }
    }

    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }

    public class PageLinkBuilder
    {
        private readonly string _baseUrl;
        private readonly string _controllerName;
        public PageLinkBuilder(string baseUrl, string controllerName, int totalPages, FilterRequest filter)
        {
            _baseUrl = baseUrl;
            _controllerName = controllerName;

            Current = GeneratePageLink(filter.PageNumber, filter.PageSize, filter.Filter, filter.Order);
            First = GeneratePageLink(1, filter.PageSize, filter.Filter, filter.Order);
            Last = GeneratePageLink(totalPages, filter.PageSize, filter.Filter, filter.Order);
            Next = GeneratePageLink(filter.PageNumber == totalPages ? totalPages : filter.PageNumber + 1, filter.PageSize, filter.Filter, filter.Order);
            Previous = GeneratePageLink(filter.PageNumber == 1 ? 1 : filter.PageNumber - 1, filter.PageSize, filter.Filter, filter.Order);
        }

        private string GeneratePageLink(int pageNumber, int pageSize, string? filter = null, string? order = null)
        {
            var url = $"{_baseUrl}{_controllerName}?PageNumber={pageNumber}&PageSize={pageSize}&";

            if (!string.IsNullOrEmpty(filter))
                url += $"Filter={filter}&";

            if (!string.IsNullOrEmpty(order))
                url += $"Order={order}&";

            return url.TrimEnd('&');
        }

        public string Current { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}
