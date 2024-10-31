using StockMate.Domain.Models;
using StockMate.Domain.Services;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels
{
    public class CryptoAssetViewModel
    {
        private readonly ICryptoAssetService _cryptoAssetService;

        public CryptoAssetViewModel(ICryptoAssetService cryptoAssetService)
        {
            _cryptoAssetService = cryptoAssetService;
        }

        public CryptoAsset Bitcoin { get; set; }
     

        public static CryptoAssetViewModel LoadCryptoAssetViewModel(ICryptoAssetService cryptoAssetService)
        {
            var cryptoAssetViewModel = new CryptoAssetViewModel(cryptoAssetService);
            cryptoAssetViewModel.LoadCryptoAssets();
            return cryptoAssetViewModel;
        }

        private void LoadCryptoAssets()
        {
            _cryptoAssetService.GetCryptoAsset("BTCUSD").ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Bitcoin = task.Result;
                }
            });

           
        }
    }
}
