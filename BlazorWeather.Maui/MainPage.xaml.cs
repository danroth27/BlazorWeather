using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace BlazorWeather.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
                        ?.ShowNotification("Tray Clicked", "Great job!", "You're using Blazor and .NET MAUI like pro! 😎");
            }
        }
    }
}
