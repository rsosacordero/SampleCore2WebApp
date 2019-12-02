using System.Net;

namespace EF_WWT.Exceptions
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiError(string message, string detail, HttpStatusCode statusCode)
        {
            Message = message;
            Detail = detail; 
            StatusCode = statusCode;
        }
    }
}
