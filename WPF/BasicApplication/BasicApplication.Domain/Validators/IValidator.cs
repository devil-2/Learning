using BasicApplication.Domain.Models;
using System.Threading.Tasks;

namespace BasicApplication.Domain.Validators
{
    public interface IValidator
    {
        Task Validate();
    }
}


