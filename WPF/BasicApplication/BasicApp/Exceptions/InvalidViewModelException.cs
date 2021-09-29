using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicApp.Exceptions
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
