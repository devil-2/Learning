using System.Collections.Generic;
using BasicApp.Commands;
using BasicApp.Enumerations;
using BasicApp.State.Authenticators;
using BasicApp.State.Navigators;
using BasicApp.ViewModels.Factories;
using BasicApplication.Domain.Models;

namespace BasicApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public Command UpdateCurrentViewModelCommand { get; }
        public bool IsLoggedIn => false;// _authenticator.IsLoggedIn;
                                        // public ViewModelBase CurrentViewModel => _navigator?.CurrentViewModel;

        public IEnumerable<Menu> MenuList { get; }

        public MainViewModel(AdminMenuListFactory menuNavigation)
        {
            MenuList = menuNavigation.GetMenus();
        }

        //public MainViewModel(INavigator navigator, IAuthenticator authenticator, ISimpleTraderViewModelFactory _viewModelFactory, MenuNavigationViewModel menuNavigation)
        //{
        //    _navigator = navigator;
        //    _authenticator = authenticator;
        //    MenuNavigation = menuNavigation;
        //    _navigator.StateChanged += Navigator_StateChanged;
        //    _authenticator.StateChanged += Authenticator_StateChanged;
        //    UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
        //    UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        //}

        private void Authenticator_StateChanged()
        {
          //  OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChanged()
        {
            //OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
