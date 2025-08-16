using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICryptoService _cryptoService;
        public ObservableCollection<CryptoCurrency> TopCurrencies { get; set; } = new();
        public ICommand LoadTopCurrenciesCommand { get; }
        public HomeViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            LoadTopCurrenciesCommand = new AsyncRelayCommand(LoadDataAsync);

            LoadTopCurrenciesCommand.Execute(null);
        }

        private async Task LoadDataAsync()
        {
            TopCurrencies.Clear();
            var data = await _cryptoService.GetTopCryptoAsync(10);

            foreach (var item in data)
            {
                TopCurrencies.Add(item);
            }
        }
    }
}
