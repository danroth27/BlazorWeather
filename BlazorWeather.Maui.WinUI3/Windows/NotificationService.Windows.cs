using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui;

namespace BlazorWeather.Maui.Windows
{
	public class NotificationService : INotificationService
	{
		public void ShowNotification(string title, string subtitle, string body)
		{
			new ToastContentBuilder()
				.AddToastActivationInfo(null, ToastActivationType.Foreground)
				.AddAppLogoOverride(new Uri("ms-appx:///Assets/dotnet_bot.png"))
				.AddText(title, hintStyle: AdaptiveTextStyle.Header)
				.AddText(subtitle, hintStyle: AdaptiveTextStyle.Subtitle)
				.AddText(body, hintStyle: AdaptiveTextStyle.Body)
				.Show();
		}
	}
}
