using System;
using Microsoft.Extensions.DependencyInjection;
using WeatherClient;

namespace BlazorWeather
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorWeather(this IServiceCollection services, string baseUri)
        {
            services.AddHttpClient<IWeatherService, WeatherService>(httpClient => httpClient.BaseAddress = new Uri(baseUri));
            services.AddSingleton<AppState>();
            services.AddSingleton<DisplayHelper>();
            return services;
        }
    }
}
