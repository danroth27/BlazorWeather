using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClient;

namespace BlazorWeather
{
    public class DisplayHelper
    {
        private readonly AppState appState;

        public DisplayHelper(AppState appState)
        {
            this.appState = appState;
        }

        public Temperature Convert(Temperature temp)
        {
            if (appState.UnitOption == "imperial" && temp.Unit == "C")
            {
                return new Temperature { Value = Math.Round(temp.Value * 9 / 5 + 32), Unit = "F" };
            }
            else if (appState.UnitOption != "imperial" && temp.Unit == "F")
            {
                return new Temperature { Value = Math.Round((temp.Value - 32) * 5 / 9), Unit = "C" };
            }
            else
            {
                return temp;
            }
        }

        public string DisplayTemp(Temperature temp)
        {
            var convertedTemp = Convert(temp);
            return $"{convertedTemp.Value}˚{convertedTemp.Unit}";
        }

        public string DisplayCurrentTemp() => DisplayTemp(appState.Weather.CurrentWeather.Temperature);

        public string TempUnit() => appState.UnitOption == "imperial" ? "F" : "C";
        public string SpeedUnit() => appState.UnitOption == "metric" ? "km/h" : "mph";

        public double ConvertSpeed(double mph) => appState.UnitOption == "metric" ? Math.Round(mph * 1.609344) : mph;

        public string DisplayWindSpeed(WeatherSnapshot weather) => $"{ConvertSpeed(weather.WindSpeed)} {SpeedUnit()}";

        public string DisplayCurrentWindSpeed() => DisplayWindSpeed(appState.Weather.CurrentWeather);

        public string DisplayPrecipationProbability(WeatherResponse weather) => $"{weather.DailyForecasts.First().Day.PrecipitationProbability}%";

        public string DisplayCurrentPrecipationProbability() => DisplayPrecipationProbability(appState.Weather);
    }
}
