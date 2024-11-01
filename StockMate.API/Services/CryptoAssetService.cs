using StockMate.Domain.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockMate.Domain.Services
{
    public class CryptoAssetService : ICryptoAssetService
    {
        private readonly HttpClient _httpClient;

        public CryptoAssetService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<CryptoAsset> GetCryptoAsset(string symbol)
        {
            var response = await _httpClient.GetStringAsync($"https://financialmodelingprep.com/api/v3/quote/{symbol}?apikey=76ae2ead5f88847fb8d8b9ed2b27b4c7");
            var jsonDocument = JsonDocument.Parse(response);
            var root = jsonDocument.RootElement[0]; // Pobieramy pierwszy element tablicy

            return new CryptoAsset
            {
                Symbol = root.GetProperty("symbol").GetString(),
                Name = root.GetProperty("name").GetString(),
                Price = root.GetProperty("price").GetDecimal(),
                Change = root.GetProperty("change").GetDecimal(),
                ChangesPercentage =root.GetProperty("changesPercentage").GetDecimal(),
                DayLow = root.GetProperty("dayLow").GetDecimal(),
                DayHigh = root.GetProperty("dayHigh").GetDecimal()
            };
        }

      
        
    }
}
