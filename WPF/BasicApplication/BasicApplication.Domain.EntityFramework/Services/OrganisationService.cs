using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicApplication.Domain.EntityFramework.Services.Common;
using BasicApplication.Domain.Models;
using BasicApplication.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace BasicApplication.Domain.EntityFramework.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly AppDbContextFactory _appDbContextFactory;
        private readonly NonQueryDataService<Organisation> _nonQuery;

        public OrganisationService(AppDbContextFactory appDbContextFactory, NonQueryDataService<Organisation> nonQuery)
        {
            _appDbContextFactory = appDbContextFactory;
            _nonQuery = nonQuery;
        }

        public async Task<Organisation> Create(Organisation model)
        {

            return await _nonQuery.Create(model);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _nonQuery.Delete(id);
        }

        public async Task<IEnumerable<Organisation>> Get()
        {
            using var ctx = _appDbContextFactory.CreateDbContext();

            IEnumerable<Organisation> entities = await ctx.Organisations
                .Include(x => x.Packages).ThenInclude(x => x.Profiles).ThenInclude(x => x.Users)
                .Include(x => x.Packages).ThenInclude(x => x.Profiles).ThenInclude(x => x.Menus)
                .Include(x => x.Address)
                .ToListAsync();

            return entities;
        }

        public async Task<Organisation> Get(Guid id)
        {
            using var ctx = _appDbContextFactory.CreateDbContext();

            Organisation entity = await ctx.Organisations
                .Include(x => x.Packages).ThenInclude(x => x.Profiles).ThenInclude(x => x.Users)
                .Include(x => x.Packages).ThenInclude(x => x.Profiles).ThenInclude(x => x.Menus)
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return entity;
        }

        public async Task<Organisation> Update(Guid id, Organisation model)
        {
            return await _nonQuery.Update(id, model);
        }
    }
}
