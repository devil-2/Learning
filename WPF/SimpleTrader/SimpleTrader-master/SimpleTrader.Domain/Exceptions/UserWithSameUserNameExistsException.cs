using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class UserWithSameUserNameExistsException : Exception
    {
        private readonly string _email;
        public UserWithSameUserNameExistsException(string email)
        {
            _email = email;
        }

        public UserWithSameUserNameExistsException(string email, string message) : base(message)
        {
            _email = email;
        }

        public UserWithSameUserNameExistsException(string email, string message, Exception innerException) : base(message, innerException)
        {
            _email = email;
        }
    }
}
