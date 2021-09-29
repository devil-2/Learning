using BasicApp.Helpers;
using BasicApp.ViewModels;
using BasicApp.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicApp
{
    public static class ConfigureService {

        public static void RegisterDependency(HostBuilderContext context, IServiceCollection services)
        {
          //  services.AddSingleton<MainWindow>();
            //View Models
            services.AddScoped<MainViewModel>();
            services.AddScoped<MenuNavigationViewModel>();
            services.AddScoped<AdminMenuListFactory>();
            services.AddScoped<MenuGridHelper>();
            
            // Main Window
            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
        }
    }

}
