using StockMate.Domain.Services;
using StockMate.WPF.State.Navigation;
using StockMate.WPF.ViewModels;
using StockMate.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace StockMate.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand         //Ta klasa jest komendą (implementującą interfejs ICommand) odpowiedzialną za aktualizację bieżącego ViewModelu w aplikacji
    {
        public event EventHandler? CanExecuteChanged;
        private readonly INavigator _navigator;
        private readonly IStockMateViewModelAbstractFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IStockMateViewModelAbstractFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
