using Newtonsoft.Json;
using StockMate.Domain.Models;
using StockMate.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockMate.API.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private const string ApiKey = "76ae2ead5f88847fb8d8b9ed2b27b4c7"; // Wstaw tutaj swój klucz API
        private const string BaseUri = "https://financialmodelingprep.com/api/v3/";
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {

            using (HttpClient client = new HttpClient())
            {



                string uri = $"{BaseUri}{GetUriSuffix(indexType)}?apikey={ApiKey}";




                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
                majorIndex.Type = indexType;
                return majorIndex;

            }
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return "dowjones_constituent";
                case MajorIndexType.Nsdaq:
                    return "nasdaq_constituent";

                default:
                    return "dowjones_constituent";
            }
        }
    }
}