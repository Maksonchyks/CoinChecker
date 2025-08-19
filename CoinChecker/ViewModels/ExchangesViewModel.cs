using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoinChecker.Core;
using CoinChecker.Models;
using CoinChecker.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace CoinChecker.ViewModels
{
    public class ExchangesViewModel : ViewModelBase
    {
        private readonly ICryptoService _cryptoService;
        public ICommand LoadTopCurrencyByMarketAsyncCommand { get; }
        public ICommand LoadAllMarketPlacesAsyncCommand { get; }
        private ObservableCollection<CryptoMarket> _topCurrencyByMarket = new();
        private ObservableCollection<MarketPlace> _allMarketPlaces = new();

        public ExchangesViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;

            LoadTopCurrencyByMarketAsyncCommand = new AsyncRelayCommand<string>(LoadTopCurrencyByMarketAsync);
            LoadAllMarketPlacesAsyncCommand = new AsyncRelayCommand(LoadAllMarketPlacesAsync);
        }

        public ObservableCollection<CryptoMarket> TopCurrencyByMarket
        {
            get => _topCurrencyByMarket;
            set
            {
                _topCurrencyByMarket = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MarketPlace> AllMarketPlaces
        {
            get => _allMarketPlaces;
            set
            {
                _allMarketPlaces = value;
                OnPropertyChanged();
            }
        }

        private async Task LoadTopCurrencyByMarketAsync(string? exchanges)
        {
            if (string.IsNullOrEmpty(exchanges))
            {
                TopCurrencyByMarket.Clear();
                return;
            }

            var currencies = await _cryptoService.GetTopCurrencyByMarketAsync(exchanges);

            TopCurrencyByMarket.Clear();
            foreach (var currency in currencies)
            {
                TopCurrencyByMarket.Add(currency);
            }

        }
        private async Task LoadAllMarketPlacesAsync()
        {
            var markets = await _cryptoService.GetallMarketPlacesAsync(20);

            AllMarketPlaces.Clear();
            foreach (var market in markets)
            {
                AllMarketPlaces.Add(market);
            }

        }
    }
}
