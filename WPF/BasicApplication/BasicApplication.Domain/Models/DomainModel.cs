using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BasicApplication.Domain.Enumerations;
using BasicApplication.Domain.Validators;

namespace BasicApplication.Domain.Models
{

    public class DomainModel : BaseDomainModel, IValidateDomain
    {
        private readonly IList<IValidator> _validators;
        public Status Status { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        public DateTime ValidTill { get; set; }

        public DomainModel()
        {
            _validators = new List<IValidator>();
        }

        public async Task AddValidator(IValidator validator)
        {
            await Task.Run(() => _validators.Add(validator));
        }

        public virtual async Task Validate()
        {
            foreach (var validator in _validators)
            {
                await validator?.Validate();
            }
        }
    }
}
