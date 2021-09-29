using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BasicApplication.Domain.Enumerations;

namespace BasicApplication.Domain.Models
{
    public class Menu : DomainModel, IEquatable<Menu>
    {

        public Guid ParentId { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; } 
        [MaxLength(100), Required]
        public string ToolTip { get; set; }
        [MaxLength(100), Required]
        public string Controller { get; set; }
        [MaxLength(100), Required]
        public string Action { get; set; }
        public Rights Rights { get; set; }
        public int Sequence { get; set; }
        public MenuType MenuType { get; set; } 

        [NotMapped]
        public IStyle Style { get; set; }
        [NotMapped]
        public int Row { get; set; }
        [NotMapped]
        public int Col { get; set; }
        public bool Equals(Menu other)
        {
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
