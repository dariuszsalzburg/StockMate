using StockMate.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockMate.WPF.State.Navigation
{
    public interface INavigator
    {
        ViewModelBase CurrentViewMOdel { get; }
        ICommand UpdateCurrentViewModelCommand { get; }


    }
}
