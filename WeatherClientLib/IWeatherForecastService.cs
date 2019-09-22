using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherClientLib.Model;

namespace WeatherClientLib
{
    public interface IWeatherForecastService
    {
        Task<Location> GetLocationByGeolocation(decimal latitude, decimal longitude);

        Task<Location[]> GetLocationsByText(string search);

        IAsyncEnumerable<WeatherResponse> GetStreamingWeather(string locationKey, CancellationToken token);

        Task<WeatherResponse> GetWeather(string locationKey);
    }
}