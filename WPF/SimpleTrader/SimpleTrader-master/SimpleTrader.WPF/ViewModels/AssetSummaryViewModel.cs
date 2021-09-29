using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.State.Assets;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;

        public double AccountBalance => _assetStore.AccountBalance;
        public AssetListingViewModel AssetListingViewModel { get; }

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;
            _assetStore.StateChanged += OnStateChanged;
            AssetListingViewModel = new AssetListingViewModel(_assetStore, assets => assets.Take(3));
        }

        private void OnStateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
        }
    }
}

