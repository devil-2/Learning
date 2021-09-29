using System;
using Microsoft.EntityFrameworkCore;

namespace BasicApplication.Domain.EntityFramework
{
    public class AppDbContextFactory 
    {
        //private readonly string _connectionString;
        private readonly Action<DbContextOptionsBuilder> _actionSqlLite;

        public AppDbContextFactory(Action<DbContextOptionsBuilder> actionSqlLite)
        {
            _actionSqlLite = actionSqlLite;
        }
        public AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            _actionSqlLite(options);

            return new AppDbContext(options.Options);
        }
    }
}
