using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicApplication.Domain.Models
{
    public class Package : DomainModel
    {
        [MaxLength(50), Required]
        public string Name { get; set; }
        public IEnumerable<Profile> Profiles { get; set; }
    
        public override string ToString()
        {
            return Name;
        }
    }
}
