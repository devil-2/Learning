using System.Threading.Tasks;

namespace SimpleTrader.WPF.Commands
{
    public abstract class GenericCommandAsync<T> : CommandAsync
    {
        public abstract Task ExecuteCommandAsync(T parameter);

        public override async Task ExecuteCommandAsync(object parameter)
        {
            IsExecuting = true;

            await ExecuteCommandAsync((T)parameter);

            IsExecuting = false;
        }
    }
}
