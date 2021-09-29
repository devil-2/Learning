using BasicApp.State.Navigators;

namespace BasicApp.Commands
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
