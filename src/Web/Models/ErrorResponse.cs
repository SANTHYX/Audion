namespace Web.Models
{
    public record ErrorResponse
    {
        public int StatusCode {  get; init; }
        public string Message { get; init; }

        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
