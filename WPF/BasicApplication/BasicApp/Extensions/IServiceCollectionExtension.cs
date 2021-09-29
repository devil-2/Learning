using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApp.State.Navigators;
using BasicApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.Extensions
{
    public static class IServiceCollectionExtension
    {

        public static void AddSigletonViewModelFactories<T>(this IServiceCollection services) where T : ViewModelBase
        {
            services.AddSingleton<CreateViewModel<T>>(service =>
            {
                return () => service.GetRequiredService<T>();
            });
        }
        public static void AddScopedViewModelFactories<T>(this IServiceCollection services) where T : ViewModelBase
        {
            services.AddScoped<CreateViewModel<T>>(service =>
            {
                return () => service.GetRequiredService<T>();
            });
        }
        public static void AddTransientViewModelFactories<T>(this IServiceCollection services) where T : ViewModelBase
        {
            services.AddTransient<CreateViewModel<T>>(service =>
            {
                return () => service.GetRequiredService<T>();
            });
        }

        public static void AddSingletonViewModelDelegateRenavigator<T>(this IServiceCollection services) where T : ViewModelBase
        {
            services.AddSingleton<ViewModelDelegateRenavigator<T>>();
        }
        public static void AddScopedViewModelDelegateRenavigator<T>(this IServiceCollection services) where T : ViewModelBase
        {
            services.AddScoped<ViewModelDelegateRenavigator<T>>();
        }
        public static void AddTransientViewModelDelegateRenavigator<T>(this IServiceCollection services) where T : ViewModelBase
        {
            services.AddTransient<ViewModelDelegateRenavigator<T>>();
        }

        public static ViewModelDelegateRenavigator<T> GetRequiredViewModelDelegateRenavigator<T>(this IServiceProvider services) where T : ViewModelBase
        {
            return services.GetRequiredService<ViewModelDelegateRenavigator<T>>();
        }
    }
}
