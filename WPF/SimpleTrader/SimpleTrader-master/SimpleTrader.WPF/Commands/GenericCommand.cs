namespace SimpleTrader.WPF.Commands
{
    public abstract class GenericCommand<T> : Command
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
