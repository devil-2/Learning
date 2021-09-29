using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFrameWork;
using SimpleTrader.EntityFrameWork.Services;
using SimpleTrader.FinancialModeingPrepApi;
using SimpleTrader.FinancialModeingPrepApi.Services;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.State.Assets;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Windows;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                    c.AddEnvironmentVariables();
                })
                .ConfigureServices((context, s) =>
                {
                    RegisterDependency(context, s);
                });
        }

        private void InitDB()
        {
            SimpleTraderDbContextFactory dbContextFactory = _host.Services.GetRequiredService<SimpleTraderDbContextFactory>();
            using var context = dbContextFactory.CreateDbContext();
            context.Database.Migrate();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            InitDB();

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

        private static void RegisterDependency(HostBuilderContext context, IServiceCollection services)
        {

            string apiKey = context.Configuration.GetValue<string>("FINANCE_API_KEY");
            bool userSqlServer = context.Configuration.GetValue<bool>("UseSqlServer");

            // Db Context
            if (userSqlServer)
            {
                string cStrSqlServer = context.Configuration.GetConnectionString("SimpleTrader");
                void actionSqlServer(DbContextOptionsBuilder o) => o.UseSqlServer(cStrSqlServer);
                services.AddDbContext<SimpleTraderDbContext>(actionSqlServer);
                services.AddSingleton(s => new SimpleTraderDbContextFactory(actionSqlServer));
            }
            else
            {
                string cStrSqlLite = context.Configuration.GetConnectionString("SimpleTraderSqlite");
                void actionSqlLite(DbContextOptionsBuilder o) => o.UseSqlServer(cStrSqlLite);
                services.AddDbContext<SimpleTraderDbContext>(actionSqlLite);
                services.AddSingleton(s => new SimpleTraderDbContextFactory(actionSqlLite));
            }

            services.AddSingleton(s => new FinancialModelingPrepHttpClientFactory(apiKey));

            //View Models
            services.AddScoped<MainViewModel>();
            services.AddSingleton<PortfolioViewModel>();
            services.AddSingleton<BuyViewModel>();
            services.AddSingleton<AssetSummaryViewModel>();

            services.AddSingleton(
                service => new RegisterViewModel(
                    service.GetRequiredViewModelDelegateRenavigator<HomeViewModel>(),
                    service.GetRequiredViewModelDelegateRenavigator<HomeViewModel>(),
                    service.GetRequiredService<IAuthenticator>())
            );

            services.AddSingleton(service => new LoginViewModel(
                service.GetRequiredService<IAuthenticator>(),
                service.GetRequiredViewModelDelegateRenavigator<HomeViewModel>(),
                service.GetRequiredViewModelDelegateRenavigator<RegisterViewModel>()));

            services.AddSingleton(service => new HomeViewModel(
                    MajorIndexListingViewModel.LoadMajorIndexViewModel(
                    service.GetRequiredService<IMajorIndexService>()),
                    service.GetRequiredService<AssetSummaryViewModel>()));

            // Services
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            // States

            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<AssetStore>();

            // Navigators for View Models
            services.AddSingletonViewModelDelegateRenavigator<HomeViewModel>();
            services.AddSingletonViewModelDelegateRenavigator<RegisterViewModel>();

            // ViewModel Factories
            services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();

            //services.AddSingleton<CreateViewModel<LoginViewModel>>(service =>
            //{
            //    return () => new LoginViewModel(service.GetRequiredService<IAuthenticator>(),
            //        service.GetRequiredViewModelDelegateRenavigator<HomeViewModel>());
            //});

            // Factories For ViewModel
            services.AddSigletonViewModelFactories<LoginViewModel>();
            services.AddSigletonViewModelFactories<HomeViewModel>();
            services.AddSigletonViewModelFactories<BuyViewModel>();
            services.AddSigletonViewModelFactories<PortfolioViewModel>();
            services.AddSigletonViewModelFactories<RegisterViewModel>();


            // Main Window
            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
        }



    }

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
