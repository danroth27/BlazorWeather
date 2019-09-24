using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWeather
{
    public class LocalStorageConfiguration : IConfiguration
    {
        private readonly ISyncLocalStorageService _localStorage;

        public LocalStorageConfiguration(ISyncLocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public string this[string key] {
            get => _localStorage.GetItem<string>(key);
            set => throw new NotImplementedException(); 
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}
