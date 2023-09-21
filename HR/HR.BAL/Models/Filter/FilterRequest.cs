namespace HR.BAL.Models.Filter
{
    public class FilterRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Filter { get; set; }
        public string? Order { get; set; }
    }
}
