using StockMate.API.Services;
using StockMate.Domain.Services;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            new MajorIndexService().GetMajorIndex(Domain.Models.MajorIndexType.DowJones).ContinueWith((task) => {


            var index = task.Result;
            
            
            });
            Window w = new MainWindow();
            w.DataContext = new MainViewModel();
            w.Show();
            base.OnStartup(e);
        }




    }

}
