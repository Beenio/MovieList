using System;
namespace MovieList.API.Exceptions
{
    public class RequestFailureException : Exception
    {
        public int ErrorCode { get; private set; }

        public RequestFailureException(int Error)
        {
            this.ErrorCode = Error;
        }

        public RequestFailureException(int Error, string message)
            : base(message)
        {
            this.ErrorCode = Error;
        }

        public RequestFailureException(int Error, string message, Exception inner)
            : base(message, inner)
        {
            this.ErrorCode = Error;
        }
    }
}