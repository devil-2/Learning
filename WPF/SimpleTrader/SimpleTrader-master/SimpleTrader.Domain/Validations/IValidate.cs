using System.Threading.Tasks;

namespace SimpleTrader.Domain.Validations
{
    public interface IValidate<T, TResult> where T : class
    {
        Task<TResult> Validate(IValidator<T, TResult> validator);
    }

    public interface IValidate<T> where T : class
    {
        Task Validate(IValidator<T> validator);
    }


}
