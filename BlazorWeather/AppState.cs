using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClient;

namespace BlazorWeather
{
    public class AppState
    {
        public Location CurrentLocation { get; set; }
        public WeatherResponse Weather { get; set; }
        public string UnitOption { get; set; } = "imperial";
        public IList<Location> FavoriteLocations { get; set; }
    }
}
