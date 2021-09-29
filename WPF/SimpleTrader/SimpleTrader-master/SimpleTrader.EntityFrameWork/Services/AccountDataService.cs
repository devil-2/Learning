using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFrameWork.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFrameWork.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            Account entity = await context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();
            IEnumerable<Account> entities = await context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .ToListAsync();

            return entities;
        }

        public async Task<Account> GetByEmail(string email)
        {
            using var context = _contextFactory.CreateDbContext();
            Account entity = await context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(x => x.AccountHolder.Email == email);

            return entity;
        }

        public async Task<Account> GetByUserName(string userName)
        {
            using var context = _contextFactory.CreateDbContext();
            Account entity = await context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(x => x.AccountHolder.UserName == userName);

            return entity;
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
