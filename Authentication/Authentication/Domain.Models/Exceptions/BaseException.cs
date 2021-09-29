using System;

namespace Domain.Models.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected string ContactAdmin = "Please contact with Admin!!";
        protected string ContactIT = "Please contact your IT Team!!";

        public BaseException()
        {
        }

        public BaseException( string message) : base(message)
        {
        }

        public BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public abstract class BaseException<T> : BaseException
    {
        public T Model { get; }
        public BaseException(T model)
        {
            Model = model;
        }

        public BaseException(T model, string message) : base(message)
        {
            Model = model;
        }

        public BaseException(T model, string message, Exception innerException) : base(message, innerException)
        {
            Model = model;
        }
    }
}
