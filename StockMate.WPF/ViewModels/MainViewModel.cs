using Microsoft.EntityFrameworkCore.Metadata;
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

    }
}
