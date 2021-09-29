using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;
        private MajorIndex _dowJones;
        private MajorIndex _nasdaq;
        private MajorIndex _sP500;

        public MajorIndex DowJones
        {
            get => _dowJones; set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }
        public MajorIndex Nasdaq
        {
            get => _nasdaq; set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }
        public MajorIndex SP500
        {
            get => _sP500; set
            {
                _sP500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(x =>
            {
                if (x.Exception == null)
                    DowJones = x.Result;
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(x =>
            {
                if (x.Exception == null)
                    Nasdaq = x.Result;
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(x =>
            {
                if (x.Exception == null)
                    SP500 = x.Result;
            });
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexListingViewModel model = new MajorIndexListingViewModel(majorIndexService);
            model.LoadMajorIndexes();
            return model;
        }
    }
}
