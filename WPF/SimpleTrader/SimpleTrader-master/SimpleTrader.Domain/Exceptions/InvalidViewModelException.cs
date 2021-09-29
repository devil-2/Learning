using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
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
