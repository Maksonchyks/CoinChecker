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
        public NavigationService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }
        public void NavigateTo<TPage>() where TPage : ViewModelBase
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var newViewModel = _serviceProvider.GetRequiredService<TPage>();
            mainViewModel.CurrentView = newViewModel;
        }
    }
}
