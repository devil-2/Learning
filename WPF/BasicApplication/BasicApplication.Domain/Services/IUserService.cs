using System.Threading.Tasks;
using BasicApplication.Domain.Models;

namespace BasicApplication.Domain.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByUserName(string userName);

        Task<User> GetByEmail(string email);
    }
}
