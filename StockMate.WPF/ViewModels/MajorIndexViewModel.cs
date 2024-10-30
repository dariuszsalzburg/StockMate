using StockMate.Domain.Models;
using StockMate.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.WPF.ViewModels
{
    public class MajorIndexViewModel
    {
        private readonly IMajorIndexService _majorIndexService;

        public MajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public MajorIndex DowJones { get; set; }
        public MajorIndex Nsdaq { get; set; }
        public static MajorIndexViewModel LaoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexViewModel majorIndexViewModel = new MajorIndexViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;

        }
        private async Task LoadMajorIndexes()
        {
            DowJones = await _majorIndexService.GetMajorIndex(MajorIndexType.DowJones);
            Nsdaq = await _majorIndexService.GetMajorIndex(MajorIndexType.Nsdaq);

        }
    }
}
