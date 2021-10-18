using Microsoft.AspNetCore.Hosting;
using System;

namespace S2A.Core.Web
{
    /// <summary>
    /// Extensions for <see cref="IWebHostBuilder"/>
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Adds the Framework construct to the ASP.Net Core application
        /// </summary>
        /// <param name="builder">The web host builder</param>
        /// <param name="configure">Custom action to configure the Framework</param>
        /// <returns></returns>
        public static IWebHostBuilder UseFramework(this IWebHostBuilder builder, Action<FrameworkConstruction> configure = null)
        {
            builder.ConfigureServices((context, services) =>
            {
                // Construct a hosted Framework
                Framework.Construct<HostedFrameworkConstruction>();

                // Setup this service collection to
                // be used by Framework 
                services.AddFramework()
                        // Add configuration
                        .AddConfiguration(context.Configuration)
                        // Add default services
                        .AddDefaultServices();

                // Fire off construction configuration
                configure?.Invoke(Framework.Construction);

                // NOTE: Framework will do .Build() from the Startup.cs Configure call
                //       app.UseFramework()
            });

            // Return builder for chaining
            return builder;
        }
    }
}
