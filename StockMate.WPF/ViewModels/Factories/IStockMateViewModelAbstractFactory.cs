using StockMate.WPF.State.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels.Factories
{
    public interface IStockMateViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewtype);
    }
}
