using StockMate.Domain.Models;
using StockMate.Domain.Services;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels
{
    public class CryptoAssetViewModel : ViewModelBase
    {
        private readonly ICryptoAssetService _cryptoAssetService;

        public CryptoAssetViewModel(ICryptoAssetService cryptoAssetService)
        {
            _cryptoAssetService = cryptoAssetService;
        }
        private CryptoAsset _btc;
        private CryptoAsset _eth;




        public CryptoAsset Bitcoin 
        { 
     
            get {
                return _btc;   
                }

            set { _btc = value; OnPropertyChanged(nameof(Bitcoin)); } 
           
        }
        public CryptoAsset Ethereum
        {

            get
            {
                return _eth;
            }

            set { _eth = value; OnPropertyChanged(nameof(Ethereum)); }

        }

        public static CryptoAssetViewModel LoadCryptoAssetViewModel(ICryptoAssetService cryptoAssetService)
        {
            var cryptoAssetViewModel = new CryptoAssetViewModel(cryptoAssetService);
            cryptoAssetViewModel.LoadCryptoAssetsBTC();
            cryptoAssetViewModel.LoadCryptoAssetsETH();
            return cryptoAssetViewModel;
        }

        private void LoadCryptoAssetsBTC()
        {
            _cryptoAssetService.GetCryptoAsset("BTCUSD").ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    Bitcoin = task.Result;
                }
            }); 
        }
        private void LoadCryptoAssetsETH()
        {
            _cryptoAssetService.GetCryptoAsset("ETHUSD").ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    Ethereum = task.Result;
                }
            });
        }
    }
}
