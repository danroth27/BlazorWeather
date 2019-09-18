using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weather;

namespace BlazorWeather
{
    public interface IWeatherForecastService
    {
        IAsyncEnumerable<WeatherResponse> GetStreamingWeather(CancellationToken token);
        Task<WeatherResponse> GetWeather();
    }
}