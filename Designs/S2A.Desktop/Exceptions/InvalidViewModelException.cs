using System;

namespace S2A.Desktop
{
    public class InvalidViewModelException : Exception
    {
        private readonly string _viewModelName;
        public InvalidViewModelException(string viewModelName)
        {
            _viewModelName = viewModelName;
        }

        public InvalidViewModelException(string viewModelName, string message) : base(message)
        {
            _viewModelName = viewModelName;
        }

        public InvalidViewModelException(string viewModelName, string message, Exception innerException) : base(message, innerException)
        {
            _viewModelName = viewModelName;
        }
    }
}
