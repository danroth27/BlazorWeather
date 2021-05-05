using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherClient
{
    public interface IWeatherService
    {
        Task<IEnumerable<Location>> GetLocations(string query = null);
        Task<WeatherResponse> GetWeather(Coordinate location);
    }
}