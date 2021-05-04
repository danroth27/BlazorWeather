using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace WeatherClient
{
    public class WeatherService : IWeatherService
    {
        static List<Location> locations = new()
        {
            new Location { Name = "Redmond", Country = "USA", Coordinate = new Coordinate(47.6740, 122.1215) },
            new Location { Name = "St. Louis", Country = "USA", Coordinate = new Coordinate(38.6270, 90.1994) },
            new Location { Name = "Boston", Country = "USA", Coordinate = new Coordinate(42.3601, 71.0589) },
            new Location { Name = "NYC", Country = "USA", Coordinate = new Coordinate(40.7128, 74.0060) },
            new Location { Name = "Amsterdam", Country = "Netherlands", Coordinate = new Coordinate(52.3676, 4.9041) },
            new Location { Name = "Seoul", Country = "South Korea", Coordinate = new Coordinate(37.5665, 126.9780) },
            new Location { Name = "Johannesburg", Country = "South Africa", Coordinate = new Coordinate(26.2041, 28.0473) },
            new Location { Name = "Rio de Janeiro", Country = "Brazil", Coordinate = new Coordinate(22.9068, 43.1729) },
            new Location { Name = "Madrid", Country = "Spain", Coordinate = new Coordinate(40.4168, 3.7038) },
            new Location { Name = "Buenos Aires", Country = "Argentina", Coordinate = new Coordinate(34.6037, 58.3816) },
            new Location { Name = "Punta Cana", Country = "Dominican Republic", Coordinate = new Coordinate(18.5601, 68.3725) },
            new Location { Name = "Hyderabad", Country = "India", Coordinate = new Coordinate(17.3850, 78.4867) },
            new Location { Name = "San Francisco", Country = "USA", Coordinate = new Coordinate(37.7749, 122.4194) },
            new Location { Name = "Nairobi", Country = "Kenya", Coordinate = new Coordinate(1.2921, 36.8219) },
            new Location { Name = "Lagos", Country = "Nigeria", Coordinate = new Coordinate(6.5244, 3.3792) }
        };

        private readonly HttpClient httpClient;

        public WeatherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<IEnumerable<Location>> GetLocations(string query)
            => Task.FromResult(locations.Where(l => l.Name.Contains(query)));

        public Task<WeatherResponse> GetWeather(Coordinate location)
            => httpClient.GetFromJsonAsync<WeatherResponse>($"/weather/{location}");
    }
}
