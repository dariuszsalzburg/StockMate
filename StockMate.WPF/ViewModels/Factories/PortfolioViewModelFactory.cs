using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels.Factories
{
    public class PortfolioViewModelFactory : IStockMateViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
           return new PortfolioViewModel();
        }
    }
}
