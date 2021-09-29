using System;

namespace BasicApplication.Domain.Exceptions
{
    public class PackageNotFoundException : Exception
    {
        private readonly string _packageName;
        public PackageNotFoundException(string packageName)
        {
            _packageName = packageName;
        }

        public PackageNotFoundException(string packageName, string message) : base(message)
        {
            _packageName = packageName;
        }

        public PackageNotFoundException(string packageName, string message, Exception innerException) : base(message, innerException)
        {
            _packageName = packageName;
        }

    }
}
