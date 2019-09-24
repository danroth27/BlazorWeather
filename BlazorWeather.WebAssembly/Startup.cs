using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherClientLib;
using GeolocationService = AspNetMonsters.Blazor.Geolocation.LocationService;

namespace BlazorWeather
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, HttpWeatherForecastService>();
            services.AddScoped<GeolocationService>();
            services.AddBlazoredLocalStorage();
            services.AddScoped<PinnedLocationsService>();
            services.AddScoped<IConfiguration, LocalStorageConfiguration>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
