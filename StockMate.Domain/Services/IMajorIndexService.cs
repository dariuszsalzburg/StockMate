using StockMate.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockMate.Domain.Services
{
    public interface IMajorIndexService
    {
        Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
    }
}
