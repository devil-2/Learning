using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using S2A.Core;
using S2A.Desktop.Core;
using System.Threading.Tasks;
using System.Windows;
using static S2A.Core.FrameworkDI;
using static S2A.Desktop.DI;
using static S2A.Desktop.Core.CoreDI;

namespace S2A.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string APP_NAME = "S2A.Desktop";
        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
      
            if (SingleInstance.IsAlreadyRunning(APP_NAME))
            {
                //app is already running! Exiting the application  
                Current.Shutdown();
            }
            base.OnStartup(e);

            // Setup the main application 
            await ApplicationSetupAsync();

            // Log it
            FrameworkDI.Logger.LogDebugSource("Application starting...");

            // Setup the application view model based on if we are logged in
            //ViewModelApplication.GoToPage(
            //    // If we are logged in...
            //    await ClientDataStore.HasCredentialsAsync() ?
            //    // Go to chat page
            //    ApplicationPage.Chat :
            //    // Otherwise, go to login page
            //    ApplicationPage.Login);
            ViewModelApplication.GoToPage(ApplicationPage.Chat);
            // Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private async Task ApplicationSetupAsync()
        {
            // Setup the Framework
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddFileLogger()
                //.AddClientDataStore()
                .AddViewModels()
                .AddClientServices()
                .Build();

            //await Monitor();
        }

        private async Task Monitor()
        {
            // Ensure the client data store 
            await ClientDataStore.EnsureDataStoreAsync();

            // Monitor for server connection status
            MonitorServerStatus();

            // Load new settings
            TaskManager.RunAndForget(ViewModelSettings.LoadAsync);
        }

        /// <summary>
        /// Monitors the  website is up, running and reachable
        /// by periodically hitting it up
        /// </summary>
        private void MonitorServerStatus()
        {
           // Create a new endpoint watcher
           var httpWatcher = new HttpEndpointChecker(
               // Checking 
               Configuration["Server:HostUrl"],
               // Every 20 seconds
               interval: 20000,
               // Pass in the DI logger
               logger: Framework.Provider.GetService<ILogger>(),
               // On change...
               stateChangedCallback: (result) =>
               {
                    // Update the view model property with the new result
                    ViewModelApplication.ServerReachable = result;
               });
        }

    }
}
