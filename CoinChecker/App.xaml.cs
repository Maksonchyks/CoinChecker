using System.Configuration;
using System.Data;
using System.Windows;
using CoinChecker.Services.Interfaces;
using CoinChecker.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using CoinChecker.ViewModels;

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
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<MainViewModel>();

        services.AddTransient<HomeViewModel>();
        services.AddTransient<DetailsViewModel>();

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainViewModel = _serviceProvider.GetService<MainViewModel>();

        var mainWindow = new MainWindow();

        mainWindow.DataContext = mainViewModel;
        mainWindow.Show();

        base.OnStartup(e);
    }

}

