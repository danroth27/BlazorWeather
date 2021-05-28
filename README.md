# Blazor Weather

A simple cross-platform weather app implemented using Blazor and .NET MAUI

## Run the sample

Install [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) and setup [.NET MAUI](https://github.com/dotnet/maui/wiki/Getting-Started),

### Windows

To run the Windows version of the app, open the solution in the latest [Visual Studio preview](https://visualstudio.com/preview).

Select the "BlazorWeather.Maui.WinUI3 (Package)" project as the startup project and make sure the x64 platform is selected.

Run the app using <kbd>F5</kbd> or <kbd>Ctrl+F5</kbd>.

### Android

Start the Android emulator first, and then run:

```
dotnet build BlazorWeather.Maui -t:Run -f net6.0-android
```

To run from Visual Studio, select the BlazorWeather.Maui as the startup project, and select Android Emulator in the Run button drop down. Run the app using <kbd>F5</kbd> or <kbd>Ctrl+F5</kbd>.

### iOS

```
dotnet build BlazorWeather.Maui -t:Run -f net6.0-ios
```

### Mac

```
dotnet build BlazorWeather.Maui -t:Run -f net6.0-maccatalyst
```

## Known issues

- Referencing scoped CSS bundles isn't working properly yet.
  - Workaround: Reference the scope bundle directly
- Configuring a root component for a `BlazorWebView` from a different project has some issues.
  - Workaround: Wrap the root component in another component in the .NET MAUI project.