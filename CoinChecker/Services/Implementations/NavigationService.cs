using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinChecker.Core;
using CoinChecker.Services.Interfaces;
using CoinChecker.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CoinChecker.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MainViewModel _mainViewModel;
        public NavigationService(MainViewModel mainViewModel, IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            _mainViewModel = mainViewModel;
        }
        public void NavigateTo<TPage>() where TPage : ViewModelBase
        {
            var newViewModel = _serviceProvider.GetService<TPage>();
            _mainViewModel.CurrentView = newViewModel;
        }
    }
}
