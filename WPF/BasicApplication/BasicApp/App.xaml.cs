using System.Windows;
using BasicApplication.Domain.EntityFramework;
using BasicApplication.Domain.Models;
using BasicApplication.Domain.Services;
using BasicApplication.Iot.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BasicApplication.Domain.EntityFramework.Extensions;
namespace BasicApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            AppHostBuilder.RegisterServices = RegisterDependency;
            _host = AppHostBuilder.CreateHost();
        }

        private void RegisterDependency(HostBuilderContext context, IServiceCollection services)
        {
            ConfigureService.RegisterDependency(context, services);

        }

        protected async override void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            InitDB();

            //var t = _host.Services.GetRequiredService<IDataService<Profile>>();
            //t.Include<Profile>(x => x.Menus);
            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        protected async override void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
            
            base.OnExit(e);
        }
        private void InitDB()
        {
            AppDbContextFactory dbContextFactory = _host.Services.GetRequiredService<AppDbContextFactory>();
            using var context = dbContextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
    
}
