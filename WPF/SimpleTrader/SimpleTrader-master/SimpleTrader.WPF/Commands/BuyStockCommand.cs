using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : CommandAsync
    {
        private readonly BuyViewModel _buyViewModel;
        private readonly IBuyStockService _buyStockService;
        private readonly IAccountStore _accountStore;

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            _buyViewModel = buyViewModel;
            _buyStockService = buyStockService;
            _accountStore = accountStore;
        }

        public override async Task ExecuteCommandAsync(object parameter)
        {
            try
            {
                Account account = await _buyStockService.BuyStock(_accountStore.CurrentAccount, _buyViewModel.Symbol, _buyViewModel.SharesToBuy);
                _accountStore.CurrentAccount = account;
                _buyViewModel.StatusMessage = "Success";
            }
            catch (Exception e)
            {
                _buyViewModel.ErrorMessage = "Transaction Failed!!";
            }
        }
    }
}
