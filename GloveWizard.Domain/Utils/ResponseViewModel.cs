using Newtonsoft.Json;
using System.Net;

namespace GloveWizard.Domain.Utils.ResponseViewModel
{
    public class ResponseViewModel<T>
    {
        public string Message { get; set; } = "Voce obteve sucesso ao obter os dados!";
        public T? Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }



        public ResponseViewModel(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }  
        public ResponseViewModel( T data,string message, HttpStatusCode statusCode)
        {
            Data = data;
            Message = message;
            StatusCode = statusCode;

        }   public ResponseViewModel(T data, HttpStatusCode statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }  public ResponseViewModel( HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

    }
}
