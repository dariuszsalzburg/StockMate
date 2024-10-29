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

            Window w = new MainWindow();
            w.DataContext = new MainViewModel();
            w.Show();
            base.OnStartup(e);
        }




    }

}
