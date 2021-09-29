using BasicApplication.Domain.Models;
using System;

namespace BasicApplication.Domain.Exceptions
{
    public class UserNameAlreadyExistsException : Exception
    {
        private readonly User _user;
        public UserNameAlreadyExistsException(User user)
        {
            _user = user;
        }

        public UserNameAlreadyExistsException(User user, string message) : base(message)
        {
            _user = user;
        }

        public UserNameAlreadyExistsException(User user, string message, Exception innerException) : base(message, innerException)
        {
            _user = user;
        }
    }
}
