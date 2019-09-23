using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherClientLib.Model;

namespace BlazorWeather
{
    public class PinnedLocationsService
    {
        private const string PinnedLocationsKey = "PINNED_LOCATIONS";
        private readonly ILocalStorageService _localStorage;

        public PinnedLocationsService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<IList<Location>> LoadPinnedLocations()
        {
            if (await _localStorage.ContainKeyAsync(PinnedLocationsKey))
            {
                var pinnedLocations = await _localStorage.GetItemAsync<Location[]>(PinnedLocationsKey);
                return new List<Location>(pinnedLocations);
            }
            else
            {
                return new List<Location>();
            }
        }

        public Task SavePinnedLocations(IEnumerable<Location> pinnedLocations)
        {
            return _localStorage.SetItemAsync(PinnedLocationsKey, pinnedLocations);
        }
    }
}
