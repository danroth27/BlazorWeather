using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazorWeather.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var services = new ServiceCollection();
            services.AddBlazorWebView();
            services.AddBlazorWeather();

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Form1>();
            var configuration = builder.Build();
            services.AddSingleton<IConfiguration>(_ => configuration);

            var blazor = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = services.BuildServiceProvider(),
            };
            blazor.RootComponents.Add<App>("#app");
            Controls.Add(blazor);

            InitializeComponent();
        }

    }
}
