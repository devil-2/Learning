using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Validations;
using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string userName, string password)
        {
            Account account = await _accountService.GetByUserName(userName);

            if (account is null) throw new UserNotFoundException(userName);

            await account.AccountHolder.Validate(new ValidateUserPassword(_accountService, _passwordHasher, password));

            return account;

        }

        public async Task<RegisterationResult> Register(string email, string userName, string password, string confirmPassword)
        {

            User user = new User
            {
                Email = email,
                UserName = userName,
                DateJoined = DateTime.Now
            };


            try
            {
                await user.Validate(new ValidatePasswordMatchWithConfirmPassword(password, confirmPassword));

                await user.Validate(new ValidateUserWithSameUserNameNotExists(_accountService));

                await user.Validate(new ValidateUserWithSameEmailNotExists(_accountService));

            }
            catch (PasswordAndConfirmPasswordDoNotMatchException)
            {
                return RegisterationResult.PasswordDoNotMatch;
            }
            catch (UserWithSameEmailExistsException)
            {
                return RegisterationResult.EmailAlreadyExists;
            }
            catch (UserWithSameUserNameExistsException)
            {
                return RegisterationResult.UserNameAlreadyExists;
            }
            catch (ArgumentNullException)
            {
                return RegisterationResult.UserNameOrEmailEmpty;
            }
            catch (Exception)
            {
                return RegisterationResult.Failed;
            }
            user.PasswordHash = _passwordHasher.HashPassword(password);

            Account account = new Account
            {
                AccountHolder = user
            };

            await _accountService.Create(account);
            return RegisterationResult.Success;
        }
    }
}
