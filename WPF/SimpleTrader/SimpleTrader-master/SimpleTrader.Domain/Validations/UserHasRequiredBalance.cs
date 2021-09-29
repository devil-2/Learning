using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Validations
{
    public class UserHasRequiredBalance : IValidator<Account>
    {
        private readonly double _requiredBalance;

        public UserHasRequiredBalance(double requiredBalance)
        {
            _requiredBalance = requiredBalance;
        }

        public async Task Verify(Account item)
        {
            await Task.Run(() =>
            {
                var allowed = item.Balance >= _requiredBalance;
                if (!allowed) throw new InsufficientFundsException(item.Balance, _requiredBalance);
            });
        }
    }
}
