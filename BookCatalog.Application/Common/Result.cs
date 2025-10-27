

using System.Net;

namespace BookCatalog.Application.Common
{
    public class Result // A detailed result model containing all the information needed for the response
    {
        public bool IsSuccess { get; protected set; }
        public string Error { get; protected set; } = string.Empty;

        public string Message { get; protected set; } = string.Empty;

        public HttpStatusCode StatusCode { get; protected set; }
    }
}
