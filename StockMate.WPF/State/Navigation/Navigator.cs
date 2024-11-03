using StockMate.WPF.Commands;
using StockMate.WPF.ViewModels;
using StockMate.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockMate.WPF.State.Navigation
{
    public class Navigator : INavigator, INotifyPropertyChanged
    {

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        {
            get 
            {

                return _currentViewModel;
            }




            set {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
                } 
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public Navigator(IStockMateViewModelAbstractFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
