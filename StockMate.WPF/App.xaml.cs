

using StockMate.Domain.Models;
using StockMate.Domain.Services;
using StockMate.Domain.Services.TransactionService;
using StockMate.EntityFramework.Services;

using StockMate.WPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace StockMate.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {

            IDataService<Account> accountService = new GenericDataService<Account>(new EntityFramework.StockMateDbContextFactory());
            ICryptoAssetService cryptoAssetService = new CryptoAssetService();
            IBuyStockService buyStockService = new BuyStockService(cryptoAssetService,accountService);
            Account buyer = await accountService.Get(1);

            await buyStockService.BuyStock(buyer, "USDd);

            Window w = new MainWindow();
            w.DataContext = new MainViewModel();
            w.Show();

            base.OnStartup(e);




        }




    }

}
