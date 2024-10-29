using StockMate.WPF.Commands;
using StockMate.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockMate.WPF.State.Navigation
{
    public class Navigator : INavigator
    {
        public ViewModelBase CurrentViewMOdel { get; set; }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewMOdelCommand(this);
    }
}
