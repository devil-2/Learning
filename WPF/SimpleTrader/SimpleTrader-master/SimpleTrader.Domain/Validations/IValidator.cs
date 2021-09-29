using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Validations
{
    public interface IValidator<T, TResult> where T : class
    {
        Task<TResult> Verify(T item);
    }

    public interface IValidator<T> where T : class
    {
        Task Verify(T item);
    }
}
