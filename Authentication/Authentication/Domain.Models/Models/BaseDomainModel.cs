using System;

namespace Domain.Models.Models
{
    public abstract class BaseDomainModel : IDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
