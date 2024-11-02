using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public CryptoAssetViewModel CryptoAssetViewModel { get; set; }

        public HomeViewModel(CryptoAssetViewModel cryptoAssetViewModel)
        {
            CryptoAssetViewModel = cryptoAssetViewModel;
        }
    }
}
