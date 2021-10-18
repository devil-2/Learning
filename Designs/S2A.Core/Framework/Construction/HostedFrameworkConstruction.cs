namespace S2A.Core
{
    /// <summary>
    /// Creates a default framework construction containing all 
    /// the default configuration and services, when used inside
    /// a project that has it's own service provider such as an
    /// ASP.Net Core website
    /// </summary>
    /// <example>
    /// 
    /// <para>
    ///     This is an example setup code for building a  Framework Construction
    /// </para>
    /// 
    /// <code>
    /// 
    ///     //  Program.cs (in BuildWebHost)
    ///     // ------------------------------
    ///             
    ///         return WebHost.CreateDefaultBuilder()
    ///             // Merge Framework into ASP.Net Core environment
    ///             .UseFramework(construct =>
    ///             {
    ///                 // Add file logger
    ///                 construct.AddFileLogger();
    ///      
    ///                 //
    ///                 // NOTE: If you want to configure anything in ConfigurationBuilder just use 
    ///                 //       ConfigureAppConfiguration(builder => {}) and then you  have
    ///                 //       access to Framework.Environment and Construction at that point
    ///                 //       like the normal flow of Framework setup
    ///                 //
    ///      
    ///                 // The last step is inside Startup Configure method to call 
    ///             })
    ///             .UseStartup&lt;Startup&gt;()
    ///             .Build();
    ///
    ///     //  Startup.cs (in Configure)
    ///     // ---------------------------
    ///     
    ///         // Use  Framework
    ///         app.UseFramework();
    /// 
    /// </code>
    /// 
    /// </example>
    public class HostedFrameworkConstruction : FrameworkConstruction
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public HostedFrameworkConstruction() : base(createServiceCollection: false)
        {

        }

        #endregion
    }

}
