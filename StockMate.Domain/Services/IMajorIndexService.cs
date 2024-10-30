using StockMate.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockMate.Domain.Services
{
    public interface IMajorIndexService
    {
        Task<List<MajorIndex>> GetMajorIndex(MajorIndexType indexType);
    }
}
