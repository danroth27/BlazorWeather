﻿using Hardcodet.Wpf.TaskbarNotification.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWeather.Maui;

namespace BlazorWeather.Maui.WinUI
{
    public class TrayService : ITrayService
    {
        WindowsTrayIcon tray;

        public Action ClickHandler { get; set; }

        public void Initialize()
        {
            tray = new WindowsTrayIcon("Platforms/Windows/Resources/trayicon.ico");
            tray.LeftClick = () =>
            {
                Microsoft.Maui.MauiWinUIApplication.Current.MainWindow.BringToFront();
                ClickHandler?.Invoke();
            };
        }
    }
}
