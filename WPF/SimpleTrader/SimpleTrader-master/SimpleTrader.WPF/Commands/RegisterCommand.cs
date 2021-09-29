using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.Commands
{
    public class RegisterCommand : CommandAsync
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        private readonly RegisterViewModel _registerViewModel;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
            _registerViewModel = registerViewModel;
        }

        public override async Task ExecuteCommandAsync(object parameter)
        {
            try
            {
                _registerViewModel.ResetMessageViewModel();
                RegisterationResult result = await _authenticator.Register(_registerViewModel.Email, _registerViewModel.UserName, _registerViewModel.Password, _registerViewModel.ConfirmPassword);

                switch (result)
                {
                    case RegisterationResult.Failed:
                        _registerViewModel.ErrorMessage = "Login Failed!";
                        break;
                    case RegisterationResult.Success:
                        _renavigator.Renavigate();
                        break;
                    case RegisterationResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Password And Confirm Password do not match!!";
                        break;
                    case RegisterationResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = $"Email {_registerViewModel.Email} already exist!!";
                        break;
                    case RegisterationResult.UserNameAlreadyExists:
                        _registerViewModel.ErrorMessage = $"UserName {_registerViewModel.UserName} already exist!!";
                        break;
                    case RegisterationResult.UserNameOrEmailEmpty:
                        _registerViewModel.ErrorMessage = "User Name or Email Can Not Be Empty!";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Login Failed!";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Login Failed!";
            }
        }
    }

}
