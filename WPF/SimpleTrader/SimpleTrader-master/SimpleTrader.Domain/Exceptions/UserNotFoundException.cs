using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserName { get; private set; }
        public UserNotFoundException(string userName)
        {
            UserName = userName;
        }

        public UserNotFoundException(string userName, string message) : base(message)
        {
            UserName = userName;
        }

        public UserNotFoundException(string userName, string message, Exception innerException) : base(message, innerException)
        {
            UserName = userName;
        }
    }
}
