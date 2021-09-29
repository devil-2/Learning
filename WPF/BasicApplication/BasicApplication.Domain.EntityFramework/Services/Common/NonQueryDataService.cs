﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BasicApplication.Domain.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : BaseDomainModel
    {
        private readonly AppDbContextFactory _contextFactory;

        public NonQueryDataService(AppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using var context = _contextFactory.CreateDbContext();
            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);

            await context.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            T entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<T> Update(Guid id, T entity)
        {
            using var context = _contextFactory.CreateDbContext();
            entity.Id = id;

            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
