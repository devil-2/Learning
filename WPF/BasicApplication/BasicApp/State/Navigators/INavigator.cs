using System;
using BasicApp.ViewModels;

namespace BasicApp.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
