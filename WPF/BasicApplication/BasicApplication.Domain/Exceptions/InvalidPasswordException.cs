using System;

namespace BasicApplication.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string message) : base(message)
        {
            ;
        }

        public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
