using StockMate.WPF.State.Navigation;
using StockMate.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockMate.WPF.Commands
{
    public class UpdateCurrentViewMOdelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private INavigator _navigator;

        public UpdateCurrentViewMOdelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewMOdel = new HomeViewModel();
                        break;
                    case ViewType.Portfolio:
                        _navigator.CurrentViewMOdel = new PortfolioViewModel();
                        break;
                    default: break;


                }
            }
        }
    }
}
