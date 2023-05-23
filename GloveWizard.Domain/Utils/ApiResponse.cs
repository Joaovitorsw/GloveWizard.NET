using GloveWizard.Domain.Constants;
using System.Net;

namespace GloveWizard.Domain.Utils.ResponseViewModel
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = ApiMessagesConstant.DefaultSuccessMessage;
        public T Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ApiResponse(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public ApiResponse(T data, string message, HttpStatusCode statusCode)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;
        }

        public ApiResponse(T data, HttpStatusCode statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public ApiResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
