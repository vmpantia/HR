namespace HR.BAL.Models.Response
{
    public class RequestResponse
    {
        public string Message { get; set; } /*Success Message or Error Message*/
        public object? Data { get; set; }
    }
}
