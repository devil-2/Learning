using SimpleTrader.Domain.Models;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public enum RegisterationResult
    {
        Failed,
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UserNameAlreadyExists,
        UserNameOrEmailEmpty
    }

    public interface IAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        Task<RegisterationResult> Register(string email, string userName, string password, string confirmPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns><cref>Account</cref></returns>
        Task<Account> Login(string userName, string password);
    }
}
