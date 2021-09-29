using BasicApplication.Domain.Models;
using System;

namespace BasicApplication.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        private readonly string _user;
        public UserNotFoundException(string user)
        {
            _user = user;
        }

        public UserNotFoundException(string user, string message) : base(message)
        {
            _user = user;
        }

        public UserNotFoundException(string user, string message, Exception innerException) : base(message, innerException)
        {
            _user = user;
        }
    }
}
