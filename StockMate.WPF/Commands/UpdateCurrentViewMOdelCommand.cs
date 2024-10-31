using StockMate.Domain.Services;
using StockMate.WPF.State.Navigation;
using StockMate.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace StockMate.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel(CryptoAssetViewModel.LoadCryptoAssetViewModel(new CryptoAssetService()));
                        break;
                    case ViewType.Portfolio:
                        _navigator.CurrentViewModel = new PortfolioViewModel();
                        break;
                    default: break;
                }
            }
        }
    }
}
