using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicApplication.Domain.EntityFramework.Services.Common;
using BasicApplication.Domain.Models;
using BasicApplication.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace BasicApplication.Domain.EntityFramework.Services
{
    public class DataService<T> : IDataService<T> where T : BaseDomainModel
    {
        private readonly AppDbContextFactory _appDbContextFactory;
        private readonly NonQueryDataService<T> _nonQuery;

        public DataService(AppDbContextFactory appDbContextFactory, NonQueryDataService<T> nonQuery)
        {
            _appDbContextFactory = appDbContextFactory;
            _nonQuery = nonQuery;
        }

        public async Task<T> Create(T model)
        {

            return await _nonQuery.Create(model);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _nonQuery.Delete(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            using var ctx = _appDbContextFactory.CreateDbContext();

            IEnumerable<T> entities = await ctx.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> Get(Guid id)
        {
            using var ctx = _appDbContextFactory.CreateDbContext();

            T entity = await ctx.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));

            return entity;
        }

        public async Task<T> Update(Guid id, T model)
        {
            return await _nonQuery.Update(id, model);
        }
    }
}
