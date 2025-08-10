using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoinChecker.Core;
using CoinChecker.Services.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace CoinChecker.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToDetailsCommand { get; }
        public SidebarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToDetailsCommand = new RelayCommand(() => _navigationService.NavigateTo<DetailsViewModel>());
            NavigateToHomeCommand = new RelayCommand(() => _navigationService.NavigateTo<HomeViewModel>());
        }
    }
}
