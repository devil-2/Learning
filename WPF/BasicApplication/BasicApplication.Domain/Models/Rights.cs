using System;
using System.ComponentModel.DataAnnotations;

namespace BasicApplication.Domain.Models
{
    public class Rights : IDomainModel {
        public Guid Id { get; set; }
        [Required]
        public bool CanView { get; set; }
        [Required]
        public bool CanAdd { get; set; }
        [Required]
        public bool CanModify { get; set; }
        [Required] 
        public bool CanDelete { get; set; }
    }

}
