using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinChecker.Models;

namespace CoinChecker.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<List<CryptoCurrency>> GetTopCryptoAsync(int limit = 10);
        Task<List<CryptoDetails>> GetCryptoDetailsAsync(string slug);
        Task<List<CryptoMarket>> GetTopCurrencyByMarketAsync(string exchangeId);
        Task<List<CryptoMarket>> GetTopMarketByCurrencyAsync(string slug);
        Task<List<MarketPlace>> GetallMarketPlacesAsync(int limit = 10);
    }

}
