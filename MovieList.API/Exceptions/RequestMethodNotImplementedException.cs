using System;
namespace MovieList.API.Exceptions
{
    public class RequestMethodNotImplementedException : Exception
    {
        public RequestMethodNotImplementedException()
        {
        }

        public RequestMethodNotImplementedException(string message)
            : base(message)
        {
        }

        public RequestMethodNotImplementedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
