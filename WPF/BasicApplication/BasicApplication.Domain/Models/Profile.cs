using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicApplication.Domain.Models
{
    public class Profile : DomainModel {
        [MaxLength(50), Required]
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }


}
