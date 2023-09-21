namespace HR.BAL.Models.Filter
{
    public class FilterResponse<TDto>
    {
        public TDto Data { get; set; }
        public Pagination Pagination { get; set; }
        public LinkBuilder Links { get; set; }
    }

    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }

    public class LinkBuilder
    {
        public string Current { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}
