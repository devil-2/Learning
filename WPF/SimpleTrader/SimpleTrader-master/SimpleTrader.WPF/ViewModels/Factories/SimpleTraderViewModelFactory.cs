using SimpleTrader.Domain.Exceptions;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelFactory : ISimpleTraderViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<PortfolioViewModel> _createPortfolioViewModel;
        private readonly CreateViewModel<BuyViewModel> _createBuyViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public SimpleTraderViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
                                            CreateViewModel<PortfolioViewModel> createPortfolioViewModel,
                                            CreateViewModel<BuyViewModel> createBuyViewModel,
                                            CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createPortfolioViewModel = createPortfolioViewModel;
            _createBuyViewModel = createBuyViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Home => _createHomeViewModel(),
                ViewType.Portfolio => _createPortfolioViewModel(),
                ViewType.Buy => _createBuyViewModel(),
                ViewType.Login => _createLoginViewModel(),
                _ => throw new InvalidViewModelException(viewType.ToString()),
            };
        }
    }
}
