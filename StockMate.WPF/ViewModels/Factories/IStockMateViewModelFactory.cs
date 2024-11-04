using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels.Factories
{
    public interface IStockMateViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
