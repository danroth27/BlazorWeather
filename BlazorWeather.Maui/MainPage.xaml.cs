using BlazorWeather;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using System;

namespace BlazorWeather.Maui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Setup configuration
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddUserSecrets(this.GetType().Assembly);
            var config = configBuilder.Build();

            // Configure services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddBlazorWeather(config["WeatherBaseUri"]);

            // Create the BlazorWebView
            var blazorWebView = new BlazorWebView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HostPage = @"wwwroot/index.html",
                Services = serviceCollection.BuildServiceProvider(),
                RootComponents =
                {
                    new RootComponent 
                    {
                        Selector = "#app", 
                        ComponentType = Type.GetType("BlazorWeather.Maui.Main")
                    }
                }
            };
            
            Content = blazorWebView;

            #if WINDOWS10_0_17763_0_OR_GREATER
            Microsoft.Maui.MauiWinUIApplication.Current.MainWindow.Title = "Blazor Weather";
            #endif

            SetupTrayIcon();
        }

        private void SetupTrayIcon()
        {
            var trayService = ServiceProvider.GetService<ITrayService>();

            if (trayService != null)
            {
                trayService.Initialize();
                trayService.ClickHandler = () => 
                    ServiceProvider.GetService<INotificationService>()
                        ?.ShowNotification("Tray Clicked", "Great job!", "Just letting you know you clicked the tray.");
            }
        }
    }
}
