using BasicApplication.Domain.Validators;
using System.Threading.Tasks;

namespace BasicApplication.Domain.Models
{
    public interface IValidateDomain {
        Task AddValidator(IValidator validator);
        Task Validate();
    }
}
