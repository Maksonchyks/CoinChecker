using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChecker.Models
{
    public class CryptoDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string? Supply { get; set; }
        public string? MarketCapUsd { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal Price { get; set; }
        public decimal ChangePercent24Hr { get; set; }
        public string? Explorer { get; set; }
    }
}
