using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApplication.Domain.Models;

namespace BasicApp.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentAccount { get; }

        bool IsLoggedIn { get; }

        //Task<RegisterationResult> Register(string email, string userName, string password, string confirmPassword);

        Task Login(string userName, string password);

        void LogOut();

        event Action StateChanged;
    }
}
