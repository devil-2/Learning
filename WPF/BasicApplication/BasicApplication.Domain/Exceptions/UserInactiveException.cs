using BasicApplication.Domain.Models;
using System;

namespace BasicApplication.Domain.Exceptions
{
    public class UserInactiveException : Exception
    {
        private readonly User _user;
        public UserInactiveException(User user)
        {
            _user = user;
        }

        public UserInactiveException(User user, string message) : base(message)
        {
            _user = user;
        }

        public UserInactiveException(User user, string message, Exception innerException) : base(message, innerException)
        {
            _user = user;
        }
    }
}
