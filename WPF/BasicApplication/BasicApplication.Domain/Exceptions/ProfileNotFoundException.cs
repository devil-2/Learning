using System;

namespace BasicApplication.Domain.Exceptions
{
    public class ProfileNotFoundException : Exception
    {
        private readonly string _profileName;

        public ProfileNotFoundException(string profileName)
        {
            _profileName = profileName;
        }

        public ProfileNotFoundException(string profileName,string message) : base(message)
        {
            _profileName = profileName;
        }

        public ProfileNotFoundException(string profileName,string message, Exception innerException) : base(message, innerException)
        {
            _profileName = profileName;
        }

    }
}
