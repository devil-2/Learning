using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BasicApplication.Domain.Models;
using BasicApplication.Domain.Services;

namespace BasicApplication.Domain.EntityFramework.Extensions
{
    public static class IncludeExtension
    {
        public async static Task<IEnumerable<T>> Include<T>(this IDataService<T> dbSet,
                                    params Expression<Func<T, object>>[] includes) where T:DomainModel
        {
            IEnumerable<T> query = null;
            foreach (var include in includes)
            {
                query = await dbSet.Include(include);
            }

            return await  dbSet.Get();
        }
    }
}
