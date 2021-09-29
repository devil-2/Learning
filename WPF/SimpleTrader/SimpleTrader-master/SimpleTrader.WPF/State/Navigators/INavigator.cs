﻿using SimpleTrader.WPF.ViewModels;
using System;

namespace SimpleTrader.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Buy,
        Login,
        Sell
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
