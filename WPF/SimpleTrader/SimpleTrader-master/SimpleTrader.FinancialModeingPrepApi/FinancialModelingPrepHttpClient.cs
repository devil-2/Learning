using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModeingPrepApi
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        private readonly string _apiKey;

        public FinancialModelingPrepHttpClient(string apiKey)
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
            _apiKey = apiKey;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await this.GetAsync($"{url}?apikey={_apiKey}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
