using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicApp.Commands
{
    public abstract class CommandAsync : ICommand
    {
        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            await ExecuteCommandAsync(parameter);

            IsExecuting = false;
        }

        public abstract Task ExecuteCommandAsync(object parameter);
    }

    public abstract class CommandAsync<T> : CommandAsync
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
