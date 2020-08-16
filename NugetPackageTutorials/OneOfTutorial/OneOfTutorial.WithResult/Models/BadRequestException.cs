using System;

namespace OneOfTutorial.WithResult.Models
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
