using SimpleTrader.Domain.Validations;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Models
{
    public class User : DomainModel, IValidate<User>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }

        public async Task Validate(IValidator<User> validator)
        {
            await validator?.Verify(this);
        }
    }


}
