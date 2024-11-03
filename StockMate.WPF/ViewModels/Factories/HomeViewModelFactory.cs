using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : IStockMateViewModelFactory<HomeViewModel>
    {
        private IStockMateViewModelFactory<CryptoAssetViewModel> _cryptoAssetViewModelfactory;

        public HomeViewModelFactory(IStockMateViewModelFactory<CryptoAssetViewModel> cryptoAssetViewModelfactory)
        {
            _cryptoAssetViewModelfactory = cryptoAssetViewModelfactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_cryptoAssetViewModelfactory.CreateViewModel());
        }
    }
}
