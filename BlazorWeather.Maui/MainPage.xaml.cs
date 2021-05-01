using BlazorWeather2021;
using Microsoft.AspNetCore.Components.WebView.Maui;
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

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddBlazorWeather();

            var blazorWebView = new BlazorWebView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HostPage = @"wwwroot/index.html",
                Services = serviceCollection.BuildServiceProvider(),
            };

            var componentType = Type.GetType("BlazorWeather.Maui.Main")
                ?? Type.GetType("BlazorWeather.Maui.WinUI3.Main");
            blazorWebView.RootComponents.Add(new RootComponent { Selector = "#app", ComponentType = componentType, });

            Content = blazorWebView;

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
                        ?.ShowNotification("Tray Clicked");
            }
        }
    }
}
