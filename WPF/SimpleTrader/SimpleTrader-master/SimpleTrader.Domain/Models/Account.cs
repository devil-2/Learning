using SimpleTrader.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Models
{
    public class Account : DomainModel, IValidate<Account>
    {
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        public ICollection<AssetTransaction> AssetTransactions { get; set; }

        public async Task Validate(IValidator<Account> validator)
        {
            await validator?.Verify(this);
        }
    }
}
