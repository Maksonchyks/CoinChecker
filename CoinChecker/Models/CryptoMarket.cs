using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChecker.Models
{
    public class CryptoMarket
    {
        public string? ExchangeId { get; set; }
        public string? BaseSymbol { get; set; }
        public string? QuoteSymbol { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal PriceUsd { get; set; }
    }

}
