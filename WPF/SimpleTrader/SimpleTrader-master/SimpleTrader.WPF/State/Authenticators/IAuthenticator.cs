using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;

namespace SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }

        bool IsLoggedIn { get; }

        Task<RegisterationResult> Register(string email, string userName, string password, string confirmPassword);

        Task Login(string userName, string password);

        void LogOut();

        event Action StateChanged;
    }
}
