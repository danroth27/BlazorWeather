using System;

namespace BlazorWeather.Maui
{
	public interface ITrayService
	{
		void Initialize();

		Action ClickHandler { get; set; }
	}
}
