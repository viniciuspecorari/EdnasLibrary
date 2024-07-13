
namespace EdnasLibrary.Application.Responses
{
    public class ErrorResponse : ApplicationException
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }

        public ErrorResponse(int statusCode, string errorMessage, string details)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            Details = details;
        }
    }
}
