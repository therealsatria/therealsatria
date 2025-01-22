using System.Net;

namespace KelanisCoalTerminal.Infrastructures.Dto
{
    public class ResponseBuilder<T>
    {
        public ResponseBuilder(
        // bool success,
        // HttpStatusCode statusCode,
        // string message,
        // T data
        )
        {
            // Success = success;
            // StatusCode = statusCode;
            // Message = message;
            // Data = data;
        }
        public bool Success
        {
            get; set;
        }

        public HttpStatusCode StatusCode
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }
        public T Data
        {
            get; set;
        }

    }
}