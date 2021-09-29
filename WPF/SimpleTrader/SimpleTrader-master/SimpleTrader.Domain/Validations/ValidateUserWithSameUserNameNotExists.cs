using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.Domain.Validations
{
    public class ValidateUserWithSameUserNameNotExists : IValidator<User>
    {
        private readonly IAccountService _accountService;

        public ValidateUserWithSameUserNameNotExists(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Verify(User user)
        {
            if (string.IsNullOrEmpty(user?.UserName))
            {
                throw new ArgumentNullException(nameof(User.UserName));
            }

            Account account = await _accountService.GetByUserName(user.UserName);

            if (account != null) throw new UserWithSameUserNameExistsException(user.UserName);
        }
    }
}
