using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.Domain.Models
{
    public enum MajorIndexType
    {
        DowJones,
        Nsdaq
     
    }
    public class MajorIndex
    {
        public string symbol { get; set; }
        public string name { get; set; }

        public string sector { get; set; }

        public MajorIndexType Type { get; set; }
    }
}
