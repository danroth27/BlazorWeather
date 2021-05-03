using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWeather.Maui
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseFormsCompatibility()
				.RegisterBlazorMauiWebView()
				.UseMauiApp<App>()
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
				.ConfigureFonts(fonts => {
					fonts.AddFont("ionicons.ttf", "IonIcons");
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