using EscritorioNitroRestaurant.Api;
using EscritorioNitroRestaurant.ViewModels;
using EscritorioNitroRestaurant.Views;
using EscritorioNitroRestaurant.Views.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace EscritorioNitroRestaurant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set;}

        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<IApiService, ApiService>();

                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<Login>(provider => new()
                {
                    DataContext = provider.GetRequiredService<LoginViewModel>()
                });
                services.AddSingleton<MainWindow>(provider => new()
                {
                    DataContext = provider.GetRequiredService<MainViewModel>()
                });

                services.AddSingleton<OrdersPage>();
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var w = AppHost.Services.GetRequiredService<MainWindow>();
            w.Show();
        
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }   
    }

}
