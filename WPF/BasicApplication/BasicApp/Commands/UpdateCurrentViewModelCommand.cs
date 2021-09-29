using BasicApp.Enumerations;
using BasicApp.State.Navigators;
using BasicApp.ViewModels.Factories;

namespace BasicApp.Commands
{
    public class UpdateCurrentViewModelCommand : Command<ViewType>
    {
        private readonly INavigator _navigator;
        private readonly ISimpleTraderViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, ISimpleTraderViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public override void ExecuteCommand(ViewType parameter)
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(parameter);
        }
    }
}
