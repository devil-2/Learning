using BasicApplication.Domain.EntityFramework;
using BasicApplication.Domain.EntityFramework.Services;
using BasicApplication.Domain.Models;
using BasicApplication.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicApplication.Iot.Hosting
{
    public static class Services
    {

        public static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            bool userSqlServer = context.Configuration.GetValue<bool>("UseSqlServer");

            if (userSqlServer)
            {
                string cStrSqlServer = context.Configuration.GetConnectionString("default");
                void actionSqlServer(DbContextOptionsBuilder o) => o.UseSqlServer(cStrSqlServer);
                services.AddDbContext<AppDbContext>(actionSqlServer);
                services.AddSingleton(s => new AppDbContextFactory(actionSqlServer));
            }
            else
            {
                string cStrSqlLite = context.Configuration.GetConnectionString("default");
                void actionSqlLite(DbContextOptionsBuilder o) => o.UseSqlServer(cStrSqlLite);
                services.AddDbContext<AppDbContext>(actionSqlLite);
                services.AddSingleton(s => new AppDbContextFactory(actionSqlLite));
            }
            // Services
            //services.AddSingleton<IAuthenticationService, AuthenticationService>();
            //services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IUserService, UserDataService>();
            services.AddSingleton<IOrganisationService, OrganisationService>();
            services.AddSingleton<IDataService<Package>, DataService<Package>>();
            services.AddSingleton<IDataService<Profile>, DataService<Profile>>();
            services.AddSingleton<IDataService<Menu>, DataService<Menu>>();

        }
    }
}
