using System.Configuration;
using System.Data;
using System.Windows;
using CoinChecker.Services.Interfaces;
using CoinChecker.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using CoinChecker.ViewModels;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CoinChecker;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    public App()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<SidebarViewModel>();

        services.AddTransient<HomeViewModel>();
        services.AddTransient<DetailsViewModel>();

        services.AddSingleton<INavigationService, NavigationService>();

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        var sidebarViewModel = _serviceProvider.GetRequiredService<SidebarViewModel>();

        mainViewModel.SidebarViewModel = sidebarViewModel;

        var mainWindow = new MainWindow
        {
            DataContext = mainViewModel
        };

        mainWindow.Show();
    }
}

