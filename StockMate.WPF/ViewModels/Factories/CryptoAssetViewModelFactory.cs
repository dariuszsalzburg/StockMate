using StockMate.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels.Factories
{
    public class CryptoAssetViewModelFactory : IStockMateViewModelFactory<CryptoAssetViewModel>
    {
        private readonly ICryptoAssetService _cryptoAssetService;

        public CryptoAssetViewModelFactory(ICryptoAssetService cryptoAssetService)
        {
            _cryptoAssetService = cryptoAssetService;
        }

        public CryptoAssetViewModel CreateViewModel()
        {
            return CryptoAssetViewModel.LoadCryptoAssetViewModel(_cryptoAssetService);
        }
    }
}
