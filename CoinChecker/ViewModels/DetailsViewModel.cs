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
using Microsoft.Windows.Themes;

namespace CoinChecker.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        private readonly ICryptoService _cryptoService;
        public ICommand LoadTopMarketsBySlugCommand { get; }
        public ICommand LoadCryptoDetailsCommand { get; }
        private ObservableCollection<CryptoMarket> _topMarketsBySlug = new();
        private CryptoDetails? _cryptoDetailsSlug;
        public DetailsViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;

            LoadCryptoDetailsCommand = new AsyncRelayCommand<string>(LoadCryptoDetails);
            LoadTopMarketsBySlugCommand = new AsyncRelayCommand<string>(LoadTopMarketsBySlug);
        }
        public ObservableCollection<CryptoMarket> TopMarketsBySlug
        {
            get => _topMarketsBySlug;
            set 
            { 
                _topMarketsBySlug = value; 
                OnPropertyChanged();
            }
        }
        public CryptoDetails? CryptoDetailsSlug
        {
            get => _cryptoDetailsSlug;
            set
            {
                _cryptoDetailsSlug = value;
                OnPropertyChanged();
            }
        }
        private async Task LoadTopMarketsBySlug(string? slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                TopMarketsBySlug.Clear();
                return;
            }

            var markets = await _cryptoService.GetTopMarketByCurrencyAsync(slug);
            
            TopMarketsBySlug.Clear();
            foreach (var market in markets)
            {
                TopMarketsBySlug.Add(market);
            }

        }
        private async Task LoadCryptoDetails(string? slug) 
        {
            if (string.IsNullOrEmpty(slug))
            {
                CryptoDetailsSlug = null;
                return;
            }

            var details = await _cryptoService.GetCryptoDetailsAsync(slug);
            CryptoDetailsSlug = details;
        }

    }
}
