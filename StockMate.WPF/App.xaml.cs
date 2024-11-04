

using Microsoft.Extensions.DependencyInjection;
using StockMate.Domain.Models;
using StockMate.Domain.Services;
using StockMate.Domain.Services.TransactionService;
using StockMate.EntityFramework;
using StockMate.EntityFramework.Services;
using StockMate.WPF.State.Navigation;
using StockMate.WPF.ViewModels;
using StockMate.WPF.ViewModels.Factories;
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

            IServiceProvider serviceProvider = CreateServiceProvider();
         
            Window w =  serviceProvider.GetRequiredService<MainWindow>();
            w.Show();
           
            base.OnStartup(e);




        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();


            services.AddSingleton<StockMateDbContextFactory>();

            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<ICryptoAssetService, CryptoAssetService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<ICryptoAssetService, CryptoAssetService>();

            services.AddSingleton<IStockMateViewModelAbstractFactory, StockMateViewModelAbstractFactory>();
            services.AddSingleton<IStockMateViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IStockMateViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<IStockMateViewModelFactory<CryptoAssetViewModel>, CryptoAssetViewModelFactory>();
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();




            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }


    }

}
