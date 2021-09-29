using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class UserWithSameEmailExistsException : Exception
    {
        private readonly string _email;
        public UserWithSameEmailExistsException(string email)
        {
            _email = email;
        }

        public UserWithSameEmailExistsException(string email, string message) : base(message)
        {
            _email = email;
        }

        public UserWithSameEmailExistsException(string email, string message, Exception innerException) : base(message, innerException)
        {
            _email = email;
        }
    }
}
