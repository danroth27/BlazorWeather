using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClientLib;

namespace BlazorWeather
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorWeather(this IServiceCollection services)
        {
            services.AddHttpClient<IWeatherForecastService, HttpWeatherForecastService>();
            services.AddScoped<IGeolocationService, GeolocationService>();
            services.AddBlazoredLocalStorage();
            services.AddScoped<PinnedLocationsService>();
            return services;
        }
    }
}
