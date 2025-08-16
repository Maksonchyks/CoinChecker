using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChecker.Models
{
    public class CryptoCurrency
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
    }
}
