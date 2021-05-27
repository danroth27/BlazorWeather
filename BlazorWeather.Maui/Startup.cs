using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.LifecycleEvents;

namespace BlazorWeather.Maui
{
  public class Startup : IStartup
  {
    public void Configure(IAppHostBuilder appBuilder)
    {
      appBuilder
        .UseFormsCompatibility()
        .RegisterBlazorMauiWebView(typeof(Startup).Assembly)
        .UseMicrosoftExtensionsServiceProviderFactory()
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        })
        .ConfigureServices(services =>
        {
#if WINDOWS
          services.AddSingleton<ITrayService, Windows.TrayService>();
          services.AddSingleton<INotificationService, Windows.NotificationService>();
#elif MACCATALYST
          services.AddSingleton<ITrayService, MacCatalyst.TrayService>();
          services.AddSingleton<INotificationService, MacCatalyst.NotificationService>();
#endif
        })
        .ConfigureLifecycleEvents(lifecycle => {
          #if ANDROID
          lifecycle.AddAndroid(d => {
            d.OnBackPressed(activity => {
              System.Diagnostics.Debug.WriteLine("Back button pressed!");
            });
          });
          #endif
        });
    }
  }
}
