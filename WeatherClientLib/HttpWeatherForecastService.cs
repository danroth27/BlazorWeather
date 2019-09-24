using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeatherClientLib.Model;

namespace WeatherClientLib
{
    public class HttpWeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private string apiKey;

        public HttpWeatherForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://dataservice.accuweather.com/");

            apiKey = configuration["accuweathertoken"];
        }

        public async Task<Location[]> GetLocationsByText(string search)
        {
            return await JsonSerializer.DeserializeAsync<Location[]>(await _httpClient.GetStreamAsync($"locations/v1/cities/US/search?{GetApiKey()}&q={search}"));
        }

        public async Task<Location> GetLocationByGeolocation(decimal latitude, decimal longitude)
        {
            return await JsonSerializer.DeserializeAsync<Location>(await _httpClient.GetStreamAsync($"locations/v1/cities/geoposition/search?{GetApiKey()}&q={latitude},{longitude}"));
        }

        public async IAsyncEnumerable<WeatherResponse> GetStreamingWeather(string locationKey, [EnumeratorCancellation] CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var weather = await GetWeatherCore(locationKey);
                yield return weather.WeatherResponse;
                await Task.Delay(weather.Expires);
            }
        }

        public async Task<WeatherResponse> GetWeather(string locationKey)
        {
            var weather = await GetWeatherCore(locationKey);
            return weather.WeatherResponse;
        }

        async Task<(WeatherResponse WeatherResponse, TimeSpan Expires)> GetWeatherCore(string locationKey)
        {
            var response = await _httpClient.GetAsync($"currentconditions/v1/{locationKey}?{GetApiKey()}&details=true");
            var model = await JsonSerializer.DeserializeAsync<Forecast[]>(await response.Content.ReadAsStreamAsync());
            var weather = new WeatherResponse(model.First());
            var expiresHeader = response.Content.Headers.Expires;
            var expires = expiresHeader.HasValue ? expiresHeader.Value.UtcDateTime.Subtract(DateTime.UtcNow) : TimeSpan.FromSeconds(2);
            return (weather, expires);
        }

        string GetApiKey() => $"apikey={apiKey}";
    }
}
