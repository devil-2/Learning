using SimpleTrader.Domain.Models;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.Domain.Validations
{
    public class ValidatePasswordMatchWithConfirmPassword : IValidator<User>
    {
        private readonly string _password;
        private readonly string _confirmPassword;

        public ValidatePasswordMatchWithConfirmPassword(string password, string confirmPassword)
        {
            _password = password;
            _confirmPassword = confirmPassword;
        }

        public async Task Verify(User item)
        {
            await Task.Run(() =>
             {
                 if (_password != _confirmPassword) throw new PasswordAndConfirmPasswordDoNotMatchException();
             });
        }
    }
}
