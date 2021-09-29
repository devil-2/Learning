using SimpleTrader.Domain.Exceptions;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.Commands
{
    public class LoginCommand : CommandAsync
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel,
            IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
            _loginViewModel = loginViewModel;
        }

        public override async Task ExecuteCommandAsync(object parameter)
        {
            _loginViewModel.ResetMessageViewModel();
            try
            {
                await _authenticator.Login(_loginViewModel.UserName, _loginViewModel.Password);
                _renavigator.Renavigate();

            }
            catch (UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Invalid User";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Invalid Password";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Login Failed";
            }
        }
    }


}
