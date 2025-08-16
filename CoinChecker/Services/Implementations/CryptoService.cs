using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CoinChecker.Models;
using CoinChecker.Services.Interfaces;
using Newtonsoft.Json.Linq;

namespace CoinChecker.Services.Implementations
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public CryptoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = "90430e2b55b6051bb6577e5be2a199545840c8b9617f9d24a2cabc0013e3a88e";
        }

        public async Task<List<CryptoCurrency>> GetTopCryptoAsync(int limit = 10)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"assets?limit={limit}&apiKey={_apiKey}");

                var json = JObject.Parse(response);
                var assets = json["data"] as JArray;

                if (assets == null) return new List<CryptoCurrency>();

                return assets
                    .Select(asset => new CryptoCurrency
                    {
                        Id = asset["id"]?.ToString(),
                        Name = asset["name"]?.ToString(),
                        Symbol = asset["symbol"]?.ToString(),
                        Price = asset["priceUsd"]?.Value<decimal>() ?? 0,
                        VolumeUsd24Hr = asset["volumeUsd24Hr"]?.Value<decimal>() ?? 0
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error: {ex.Message}");
                return new List<CryptoCurrency>();
            }
        }

        public async Task<CryptoDetails> GetCryptoDetailsAsync(string slug)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"assets/{slug}?apiKey={_apiKey}");

                var json = JObject.Parse(response);
                var data = json["data"] as JObject;

                if (data == null) return null;

                return new CryptoDetails 
                {
                        Id = data["id"]?.ToString(),
                        Name = data["name"]?.ToString(),
                        Symbol = data["symbol"]?.ToString(),
                        Supply = data["supply"]?.ToString(),
                        MarketCapUsd = data["marketCapUsd"]?.ToString(),
                        VolumeUsd24Hr = data["volumeUsd24Hr"]?.Value<decimal>() ?? 0,
                        Price = data["priceUsd"]?.Value<decimal>() ?? 0,
                        ChangePercent24Hr = data["changePercent24Hr"]?.Value<decimal>() ?? 0,
                        Explorer = data["explorer"]?.ToString()
                };
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<CryptoMarket>> GetTopCurrencyByMarketAsync(string exchangeId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"markets?exchangeId={exchangeId}&apiKey={_apiKey}");
                var json = JObject.Parse(response);
                var markets = json["data"] as JArray;

                if (markets == null) return new List<CryptoMarket>();

                return markets
                    .Select(market => new CryptoMarket
                    {
                        ExchangeId = market["exchangeId"]?.ToString(),
                        BaseSymbol = market["baseSymbol"]?.ToString(),
                        QuoteSymbol = market["quoteSymbol"]?.ToString(),
                        VolumeUsd24Hr = market["volumeUsd24Hr"]?.Value<decimal>() ?? 0,
                        PriceUsd = market["priceUsd"]?.Value<decimal>() ?? 0
                    })
                    .ToList();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error: {ex.Message}");
                return new List<CryptoMarket>();
            }
        }

        public async Task<List<CryptoMarket>> GetTopMarketByCurrencyAsync(string slug)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"assets/{slug}/markets?apiKey={_apiKey}");
                var json = JObject.Parse(response);
                var markets = json["data"] as JArray;

                if (markets == null) return new List<CryptoMarket>();

                return markets
                    .Select(market => new CryptoMarket
                    {
                        ExchangeId = market["exchangeId"]?.ToString(),
                        BaseSymbol = market["baseSymbol"]?.ToString(),
                        QuoteSymbol = market["quoteSymbol"]?.ToString(),
                        VolumeUsd24Hr = market["volumeUsd24Hr"]?.Value<decimal>() ?? 0,
                        PriceUsd = market["priceUsd"]?.Value<decimal>() ?? 0
                    })
                    .ToList();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error: {ex.Message}");
                return new List<CryptoMarket>();
            }
        }

        public async Task<List<MarketPlace>> GetallMarketPlacesAsync(int limit = 10)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"exchanges?limit={limit}&apiKey={_apiKey}");
                var json = JObject.Parse(response);
                var exchanges = json["data"] as JArray;

                if (exchanges == null) return new List<MarketPlace>();

                return exchanges
                    .Select(exchange => new MarketPlace
                    {
                        ExchangeId = exchange["exchangeId"]?.ToString(),
                        ExchangeUrl = exchange["exchangeUrl"]?.ToString()
                    })
                    .ToList();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error: {ex.Message}");
                return new List<MarketPlace>();
            }
        }
    }
}
