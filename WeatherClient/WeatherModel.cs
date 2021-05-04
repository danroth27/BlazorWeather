using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherClient2021
{
    public class WeatherResponse
    {
        public WeatherSnapshot CurrentWeather { get; set; }
        public WeatherSnapshot[] HourlyForecasts { get; set; }
        public FullDayForecast[] DailyForecasts { get; set; }
    }

    public class WeatherSnapshot
    {
        public DateTimeOffset DateTime { get; set; }
        public string Phrase { get; set; }
        public Temperature Temperature { get; set; }
        public int RelativeHumidity { get; set; }
        public int? PrecipitationProbability { get; set; }
        public int WindSpeed { get; set; } = new Random().Next(0, 40);
        public int WindDirection { get; set; } = new Random().Next(0, 360);

        public DateTimeOffset Date
        {
            set { DateTime = value; }
        }

        public string IconPhrase
        {
            set { Phrase = value; }
        }
    }

    public class Temperature
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public override string ToString() => $"{Value}˚{Unit}";
    }

    public class MinMaxTemperature
    {
        public Temperature Minimum { get; set; }
        public Temperature Maximum { get; set; }
    }

    public class DayOrNight
    {
        public string Phrase { get; set; }
        public int PrecipitationProbability { get; set; }

        public string IconPhrase
        {
            set { Phrase = value; }
        }
    }

    public class FullDayForecast
    {
        public DateTimeOffset DateTime { get; set; }
        public MinMaxTemperature Temperature { get; set; }

        public DayOrNight Day { get; set; }
        public DayOrNight Night { get; set; }

        public int ChanceOfPercipitation { get; } = new Random().Next(0, 100);

        public DateTimeOffset Date
        {
            set { DateTime = value; }
        }
    }

    public class CurrentWeather
    {
        public WeatherSnapshot[] Results { get; set; }
    }

    public class HourlyForecast
    {
        public WeatherSnapshot[] Forecasts { get; set; }
    }

    public class DailyForecast
    {
        public FullDayForecast[] Forecasts { get; set; }
    }

    public record Coordinate(double Latitude, double Longitude)
    {
        public static bool TryParse(string input, out Coordinate coordinate)
        {
            coordinate = default;
            var splitArray = input.Split(',', 2);

            if (splitArray.Length != 2)
            {
                return false;
            }

            if (!double.TryParse(splitArray[0], out var lat))
            {
                return false;
            }

            if (!double.TryParse(splitArray[1], out var lon))
            {
                return false;
            }

            coordinate = new Coordinate(lat, lon);
            return true;
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }
    }

    public class Location
    {
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }
    }

    public static class WeatherStations
    {
        public static IEnumerable<WeatherStation> GetWeatherStations(this WeatherSnapshot weather)
        {
            var rand = new Random();
            var n = rand.Next(1, 5);
            for (var i = 0; i < n; i++)
            {
                yield return new WeatherStation { CurrentWeather = weather };
            }
        }
    }

    public class WeatherStation
    {
        public string Name { get; set; } = $"Weather station {new Random().Next(1, 300)}";
        public WeatherSnapshot CurrentWeather { get; set; }
    }
}