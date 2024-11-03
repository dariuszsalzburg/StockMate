using StockMate.Domain.Services;
using StockMate.WPF.State.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels.Factories
{
    public class StockMateViewModelAbstractFactory : IStockMateViewModelAbstractFactory
    {
        private IStockMateViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private IStockMateViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;

        public StockMateViewModelAbstractFactory(IStockMateViewModelFactory<HomeViewModel> homeViewModelFactory, IStockMateViewModelFactory<PortfolioViewModel> portfolioViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                    
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                   
                default: throw new ArgumentException("ViewType does not have a ViewModel","viewType");
            }
        }
    }
}
