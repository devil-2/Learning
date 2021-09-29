using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleTrader.WPF.Commands
{
    public class SearchSymbolCommand : CommandAsync
    {
        private readonly BuyViewModel _viewModel;
        private readonly IStockPriceService _stockPriceService;

        public SearchSymbolCommand(BuyViewModel viewModel, IStockPriceService stockPriceService)
        {
            _viewModel = viewModel;
            _stockPriceService = stockPriceService;
        }

        public override async Task ExecuteCommandAsync(object parameter)
        {
            try
            {
                double stockPrice = await _stockPriceService.GetPrice(_viewModel.Symbol);
                _viewModel.StockPrice = stockPrice;
                _viewModel.SearchResultSymbol = _viewModel.Symbol.ToUpper();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
