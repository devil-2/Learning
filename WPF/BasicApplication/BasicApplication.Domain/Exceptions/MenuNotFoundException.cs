using System;

namespace BasicApplication.Domain.Exceptions
{
    public class MenuNotFoundException : Exception
    {
        public MenuNotFoundException()
        {
        }

        public MenuNotFoundException(string message) : base(message)
        {
        }

        public MenuNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
