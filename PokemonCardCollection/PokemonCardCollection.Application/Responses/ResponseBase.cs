using System.Net;

namespace PokemonCardCollection.Application.Responses
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            StatusCode = HttpStatusCode.OK;
        }

        public ResponseBase(string message)
        {
            StatusCode = HttpStatusCode.OK;
            Message = message;
        }

        public ResponseBase(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ResponseBase(HttpStatusCode statusCode, IEnumerable<string> validationErrors)
        {
            StatusCode = statusCode;
            ValidationErrors = validationErrors;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string>? ValidationErrors { get; set; }
    }
}
