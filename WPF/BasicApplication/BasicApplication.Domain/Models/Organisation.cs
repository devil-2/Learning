using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicApplication.Domain.Models
{
    public class Organisation : DomainModel
    {
        [MaxLength(50),Required]
        public string Name { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Package> Packages { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
