﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public AssetSummaryViewModel AssetSummaryViewModel { get; }

        public MajorIndexListingViewModel MajorIndexListingViewModel { get; }

        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel, AssetSummaryViewModel assetSummaryViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
            AssetSummaryViewModel = assetSummaryViewModel;
        }
    }


}
