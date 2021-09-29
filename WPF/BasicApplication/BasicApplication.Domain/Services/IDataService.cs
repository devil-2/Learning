using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicApplication.Domain.Models;

namespace BasicApplication.Domain.Services
{
    public interface IDataService<T> where T : IDomainModel
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(Guid id);
        Task<T> Create(T model);
        Task<T> Update(Guid id, T model);
        Task<bool> Delete(Guid id);
    }
}
