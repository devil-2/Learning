using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class PasswordAndConfirmPasswordDoNotMatchException : Exception
    {
        public PasswordAndConfirmPasswordDoNotMatchException()
        {
        }

        public PasswordAndConfirmPasswordDoNotMatchException(string message) : base(message)
        {
        }

        public PasswordAndConfirmPasswordDoNotMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
