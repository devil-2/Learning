using System;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public abstract class Command : ICommand
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

        public void Execute(object parameter)
        {
            IsExecuting = true;

            ExecuteCommand(parameter);

            IsExecuting = false;
        }

        public abstract void ExecuteCommand(object parameter);
    }

}
