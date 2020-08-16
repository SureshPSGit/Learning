using System;

namespace OneOfTutorial.WithExceptions.Models
{
    public class BadRequestException : Exception
    {
        public Error Error { get; }

        public BadRequestException(Error error)
        {
            Error = error;
        }
    }
}
