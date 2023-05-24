using GloveWizard.Domain.Constants;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace GloveWizard.Domain.Utils.ResponseViewModel
{
    public class PaginationResponse<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public T Data { get; set; }

        public PaginationResponse(
            int currentPage,
            int pageSize,
            int totalCount,
            int totalPages,
            T data
        )
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = totalCount;
            Data = data;
        }
    }

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
