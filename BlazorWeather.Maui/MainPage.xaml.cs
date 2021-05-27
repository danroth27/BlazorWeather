using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace BlazorWeather.Maui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetupTrayIcon();

#if WINDOWS10_0_17763_0_OR_GREATER
            Microsoft.Maui.MauiWinUIApplication.Current.MainWindow.Title = "Blazor Weather";
#endif
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
