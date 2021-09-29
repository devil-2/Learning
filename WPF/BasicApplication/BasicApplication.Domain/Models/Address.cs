using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BasicApplication.Domain.Validators;

namespace BasicApplication.Domain.Models
{
    public class Address : DomainModel
    {
        [MaxLength(50)]
        public string BuildingNo { get; set; }
        [MaxLength(50)]
        public string BlockNo { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(6)]
        public long PinCode { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
