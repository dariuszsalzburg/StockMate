using Microsoft.EntityFrameworkCore.Metadata;
using StockMate.Domain.Services;
using StockMate.WPF.State.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

       

        public CryptoAssetViewModel CryptoAssetViewModel { get; }

        public MainViewModel(ICryptoAssetService cryptoAssetService)
        {
            CryptoAssetViewModel = CryptoAssetViewModel.LoadCryptoAssetViewModel(cryptoAssetService);

        }

        public MainViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
