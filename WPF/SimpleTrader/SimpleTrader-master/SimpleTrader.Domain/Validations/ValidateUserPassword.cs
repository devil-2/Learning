using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Validations
{
    public class ValidateUserPassword : IValidator<User>
    {
        private readonly string _password;
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public ValidateUserPassword(IAccountService accountService, IPasswordHasher passwordHasher, string password)
        {
            _password = password;
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task Verify(User user)
        {
            await Task.Run(() =>
            {
                PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(user.PasswordHash, _password);
                if (passwordResult != PasswordVerificationResult.Success)
                {
                    throw new InvalidPasswordException(user.UserName, _password);
                }

            });
        }
    }
}
