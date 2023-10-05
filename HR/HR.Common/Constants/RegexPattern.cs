namespace HR.Common.Constants
{
    public class RegexPattern
    {
        public const string FILTER_PATTERN = @"^([a-zA-Z0-9]+)\s*-(eq|ne|c|nc)\s*([a-zA-Z0-9]+)$";
        public const string ORDER_PATTERN = @"^([a-zA-Z0-9]+)\s*-(asc|desc)$";
    }
}
