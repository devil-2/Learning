using System;
using System.Collections.Generic;

namespace BasicApplication.Domain.Models
{
    public class User : DomainModel {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateofBirth { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Menu> Menus { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
