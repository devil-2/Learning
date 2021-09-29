using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.Domain.Validations
{
    public class ValidateUserWithSameEmailNotExists : IValidator<User>
    {
        private readonly IAccountService _accountService;

        public ValidateUserWithSameEmailNotExists(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Verify(User user)
        {
            if (string.IsNullOrEmpty(user?.Email)) throw new ArgumentNullException(nameof(User.Email));
            Account account = await _accountService.GetByEmail(user?.Email);
            if (account != null) throw new UserWithSameEmailExistsException(user.Email);
        }
    }
}
