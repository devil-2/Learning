using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Validations
{
    public class ValidateAccountExists : IValidator<Account>
    {
        private readonly string _userName;

        public ValidateAccountExists(string userName)
        {
            _userName = userName;
        }

        public async Task Verify(Account item)
        {
            await Task.Run(() =>
            {
                if (item is null)
                {
                    throw new UserNotFoundException(_userName);
                }

            });
        }
    }
}
