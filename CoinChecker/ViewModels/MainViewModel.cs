using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinChecker.Core;
using CoinChecker.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoinChecker.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _currentView;
        private SidebarViewModel? _sidebarViewModel;

        public ViewModelBase? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public SidebarViewModel? SidebarViewModel 
        {
            get => _sidebarViewModel;
            set
            {
                _sidebarViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}
