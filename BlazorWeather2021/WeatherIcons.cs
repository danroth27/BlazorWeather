using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClient2021;

namespace BlazorWeather2021
{
    public static class WeatherIcons
    {
        static Dictionary<string, string> PhraseIconMapping = new()
        {
            { "Cloudy", "cloudy" },
            { "Mostly cloudy", "cloudy" },
            { "Intermittent clouds", "partly-cloudy" },
            { "Partly sunny", "partly-cloudy" },
            { "Partly cloudy", "partly-cloudy" },
            { "Mostly clear", "clear" },
            { "Clear", "clear" },
            { "Sunny", "clear" },
            { "Mostly sunny", "clear" },
            { "Hazy sunshine", "haze" },
            { "Showers", "showers" },
            { "Thunderstorms", "thunderstorms" },
            { "Mostly cloudy w/ t-storms", "thunderstorms" },
            { "Partly sunny w/ t-storms", "thunderstorms" }
        };

        public static string GetIconUrl(this WeatherSnapshot weather) 
            => GetIconUrl(weather.Phrase, weather.DateTime);

        public static string GetIconUrl(this FullDayForecast forecast)
            => GetIconUrl(forecast.Day.Phrase, forecast.DateTime);
        
        public static string GetIconUrl(string phrase, DateTimeOffset dateTime)
        {
            var assemblyName = typeof(WeatherIcons).Assembly.GetName().Name;
            var fileName = GetIconFile(phrase, dateTime);
            return $"_content/{assemblyName}/weather-icons/{fileName}";
        }

        static string GetIconFile(string phrase, DateTimeOffset dateTime)
        {
            string fileName;
            if (!PhraseIconMapping.TryGetValue(phrase, out fileName))
            {
                fileName = "partly-cloudy";
                Console.WriteLine($"Unmapped phrase: {phrase}");
            }
            if (IsNight(dateTime))
            {
                fileName += "-night";
            }
            fileName += ".svg";
            return fileName;
        }
        static bool IsNight(DateTimeOffset dateTime) => dateTime.TimeOfDay < TimeSpan.FromHours(6) || dateTime.TimeOfDay > TimeSpan.FromHours(20);
    }
}
