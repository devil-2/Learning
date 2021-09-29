using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public InvalidPasswordException(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public InvalidPasswordException(string userName, string password, string message) : base(message)
        {
            UserName = userName;
            Password = password;
        }

        public InvalidPasswordException(string userName, string password, string message, Exception innerException) : base(message, innerException)
        {
            UserName = userName;
            Password = password;
        }
    }
}
