using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using WeatherClientLib;
using System;
using Microsoft.Extensions.Configuration;
using GeolocationService = AspNetMonsters.Blazor.Geolocation.LocationService;
using Blazored.LocalStorage;

namespace BlazorWeather
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddUserSecrets<Startup>()
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddHttpClient<IWeatherForecastService, HttpWeatherForecastService>();

            services.AddScoped<GeolocationService>();
            services.AddBlazoredLocalStorage();
            services.AddScoped<PinnedLocationsService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
