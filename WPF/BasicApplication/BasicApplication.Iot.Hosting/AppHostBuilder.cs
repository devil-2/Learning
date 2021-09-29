using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicApplication.Iot.Hosting
{
    public class AppHostBuilder
    {
        private static IHost _host;
        public static Action<HostBuilderContext, IServiceCollection> RegisterServices;

        private static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(
                c =>
                {
                    c.AddJsonFile("appsettings.json");
                    c.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    Services.Configure(context, services);
                    RegisterServices(context, services);
                });
        }

        public static IHost CreateHost(string[] args = null)
        {
            _host = CreateHostBuilder().Build();
            return _host;
        }

    }
}
