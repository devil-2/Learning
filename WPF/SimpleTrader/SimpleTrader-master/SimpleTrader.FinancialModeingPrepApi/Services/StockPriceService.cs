using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModeingPrepApi.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModeingPrepApi.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly FinancialModelingPrepHttpClientFactory _httpClientFactory;

        public StockPriceService(FinancialModelingPrepHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<double> GetPrice(string symbol)
        {
            string uri = $"stock/real-time-price/{symbol}";

            using FinancialModelingPrepHttpClient client = _httpClientFactory.CreateHttpClient();

            StockPriceResult stockPrice = await client.GetAsync<StockPriceResult>(uri);
            if (stockPrice.Price <= 0) throw new InvalidSymbolException(symbol);
            return stockPrice.Price;
        }
    }
}
