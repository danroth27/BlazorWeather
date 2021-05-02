using Blazored.LocalStorage;
using Darnton.Blazor.DeviceInterop.Geolocation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClient2021;

namespace BlazorWeather2021
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorWeather(this IServiceCollection services, string baseUri)
        {
            services.AddHttpClient<IWeatherService, WeatherService>(httpClient => httpClient.BaseAddress = new Uri(baseUri));
            services.AddScoped<IGeolocationService, GeolocationService>();
            services.AddBlazoredLocalStorage();
            services.AddScoped<PinnedLocationsService>();
            return services;
        }
    }
}
