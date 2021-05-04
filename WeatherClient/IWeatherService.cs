using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherClient
{
    public interface IWeatherService
    {
        Task<IEnumerable<Location>> GetLocations(string query);
        Task<WeatherResponse> GetWeather(Coordinate location);
    }
}