using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicApplication.Domain.Models;
using BasicApplication.Domain.Services;

namespace BasicApplication.Domain.EntityFramework.Services
{
    public class UserDataService : IUserService
    {
        private readonly DataService<User> _userService;

        public UserDataService(DataService<User> userService)
        {
            _userService = userService;
        }

        public async Task<User> Create(User model)
        {
            return await _userService.Create(model);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userService.Delete(id);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.Get();
        }

        public async Task<User> Get(Guid id)
        {
            return await _userService.Get(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            var users = await _userService.Get();
           return  users.FirstOrDefault(x => x.EmailAddress == email);
        }

        public async Task<User> GetByUserName(string userName)
        {
            var users = await _userService.Get();
            return users.FirstOrDefault(x => x.UserName == userName);
        }

        public async Task<User> Update(Guid id, User model)
        {
            return await _userService.Update(id, model);
        }
    }
}
