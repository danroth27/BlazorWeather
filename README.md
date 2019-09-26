# Blazor Weather

A Blazor Weather sample app that shows the current weather for your current location and a collection of pinned locations.

## Setup

You'll need an [Accuweather API key](https://developer.accuweather.com/) to use their services. You can sign up for a free trial - just be aware it's only good for 50 requests/day. 

To setup the API key in the Blazor WebAssembly app during development, run the app and the run `localStorage.setItem("accuweathertoken", "\"**YOUR TOKEN**\"")` in the browser dev console. Clear the API key from local storage when you're done with it

## Credits

The weather is supplied by [Accuweather](https://www.accuweather.com/). 

Geolocation is handled using [Blazor.Geolocation](https://github.com/AspNetMonsters/Blazor.Geolocation).

Local storage is handled using [Blazored.LocalStorage](https://github.com/blazored/LocalStorage).

Space Needle icon by [Blair Adams via The Noun Project](https://thenounproject.com/search/?q=space%20needle&i=915578).

The [demo site](https://aka.ms/blazorweather) is hosted on a free Azure site, so be gentle :smile:.
