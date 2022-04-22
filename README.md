# Blazor Weather

A simple cross-platform weather app implemented using Blazor and .NET MAUI

## Run the sample

Install [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) and setup [.NET MAUI](https://docs.microsoft.com/dotnet/maui/get-started/installation),

### Windows

To run the Windows version of the app, open the solution in the latest [Visual Studio 2022 preview](https://visualstudio.com/preview). You will also need to install the [Single-project MSIX Packaging Tools](https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftSingleProjectMSIXPackagingToolsDev17) Visual Studio extension.

Select the BlazorWeather.Maui project as the startup project. Also select Windows from the Run drop down menu. Run the app using <kbd>F5</kbd> or <kbd>Ctrl+F5</kbd>.

### Android

Start the Android emulator first, and then run:

```
dotnet build BlazorWeather.Maui -t:Run -f net6.0-android
```

To run from Visual Studio, select the BlazorWeather.Maui as the startup project, and select Android in the Run button drop down menu. Run the app using <kbd>F5</kbd> or <kbd>Ctrl+F5</kbd>.

### iOS

```
dotnet build BlazorWeather.Maui -t:Run -f net6.0-ios
```

### Mac

```
dotnet build BlazorWeather.Maui -t:Run -f net6.0-maccatalyst
```
