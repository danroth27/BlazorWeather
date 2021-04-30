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

            var blazorWebView = new BlazorWebView()
            {
                BackgroundColor = Colors.Orange,
                HeightRequest = 200,
                MinimumHeightRequest = 200,

                HostPage = @"wwwroot/index.html",
                Services = serviceCollection.BuildServiceProvider(),
            };

            var componentType = Type.GetType("BlazorWeather.Maui.Main");
            blazorWebView.RootComponents.Add(new RootComponent { Selector = "#app", ComponentType = componentType, });

            Content = blazorWebView;
        }
    }
}
