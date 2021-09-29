using Microsoft.EntityFrameworkCore;
using System;

namespace SimpleTrader.EntityFrameWork
{
    public class SimpleTraderDbContextFactory
    {
        private Action<DbContextOptionsBuilder> _actionSqlLite;

        public SimpleTraderDbContextFactory(Action<DbContextOptionsBuilder> actionSqlLite)
        {
            _actionSqlLite = actionSqlLite;
        }

        public SimpleTraderDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            _actionSqlLite(options);
            return new SimpleTraderDbContext(options.Options);
        }
    }
}
