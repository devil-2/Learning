using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.Commands
{
    public class RenavigateCommand : Command
    {
        private readonly IRenavigator _renavigator;

        public RenavigateCommand(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public override void ExecuteCommand(object parameter)
        {
            _renavigator.Renavigate();
        }
    }
}
