using BasicApplication.Domain.Models;
using System;

namespace BasicApplication.Domain.Exceptions
{
    public class UserEmailAlreadyExistsException : Exception
    {
        private readonly User _user;
        public UserEmailAlreadyExistsException(User user)
        {
            _user = user;
        }

        public UserEmailAlreadyExistsException(User user, string message) : base(message)
        {
            _user = user;
        }

        public UserEmailAlreadyExistsException(User user, string message, Exception innerException) : base(message, innerException)
        {
            _user = user;
        }
    }
}
