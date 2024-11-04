using System.Threading.Tasks;
using StockMate.Domain.Models;

namespace StockMate.Domain.Services
{
    public interface ICryptoAssetService
    {
        Task<CryptoAsset> GetCryptoAsset(string symbol);
       
    }
}
