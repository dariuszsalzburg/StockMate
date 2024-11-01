using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.Domain.Models
{
    public class CryptoAsset
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }

        public decimal ChangesPercentage { get; set; }

        public decimal DayLow { get; set; }

        public decimal DayHigh { get; set; }
    }
}
