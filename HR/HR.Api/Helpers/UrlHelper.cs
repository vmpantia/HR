namespace HR.Api.Helpers
{
    public class UrlHelper
    {
        private readonly IConfiguration _configuration;
        public UrlHelper(IConfiguration configuration) => _configuration = configuration;

        public string BuilUrl(string controller, int pageNumber, int pageSize, string? filter = null, string? order = null)
        {
            var url = $"{_configuration["Web:BaseApiUrl"]}{controller}?PageNumber={pageNumber}&PageSize={pageSize}&";

            if (!string.IsNullOrEmpty(filter))
                url += $"Filter={filter}&";

            if (!string.IsNullOrEmpty(order))
                url += $"Order={order}&";

            return url.TrimEnd('&');
        }
    }
}
