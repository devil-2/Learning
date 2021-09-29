using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BasicApplication.Domain.Models;

namespace BasicApp.Commands
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

    public abstract class Command<T> : Command
    {
        public override void ExecuteCommand(object parameter)
        {
            IsExecuting = true;

            ExecuteCommand((T)parameter);

            IsExecuting = false;
        }

        public abstract void ExecuteCommand(T parameter);
    }
}
