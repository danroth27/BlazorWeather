using System;
using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;
using WeatherClient;

namespace BlazorWeather
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorWeather(this IServiceCollection services, string baseUri)
        {
            services.AddHttpClient<IWeatherService, WeatherService>(httpClient => httpClient.BaseAddress = new Uri(baseUri));
            services.AddScoped<IGeolocationService, GeolocationService>();
            services.AddBlazoredLocalStorage();
            services.AddScoped<PinnedLocationsService>();
            services.AddSingleton<AppState>();
            services.AddSingleton<DisplayHelper>();
            return services;
        }
    }
}
