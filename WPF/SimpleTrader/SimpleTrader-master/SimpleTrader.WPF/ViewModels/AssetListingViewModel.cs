using SimpleTrader.WPF.State.Assets;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetListingViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;
        private readonly ObservableCollection<AssetViewModel> _assets;
        private readonly Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> _filterAssets;

        public IEnumerable<AssetViewModel> Assets => _assets;

        public AssetListingViewModel(AssetStore assetStore) : this(assetStore, asset => asset)
        {
        }

        public AssetListingViewModel(AssetStore assetStore, Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> filterAssets)
        {
            _assets = new ObservableCollection<AssetViewModel>();
            _assetStore = assetStore;
            _assetStore.StateChanged += OnAssetStore_StateChanged;
            ResetAssets();
            _filterAssets = filterAssets;
        }

        private void OnAssetStore_StateChanged()
        {
            ResetAssets();
        }
        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assets = _assetStore.AssetTransactions
                .GroupBy(x => x.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(x => x.IsPurchase ? x.Shares : -x.Shares)))
                .OrderByDescending(x => x.Shares)
                .Where(x => x.Shares > 0);
            assets = _filterAssets(assets);

            _assets.Clear();

            foreach (AssetViewModel model in assets)
            {
                _assets.Add(model);
            }
        }
    }
}

