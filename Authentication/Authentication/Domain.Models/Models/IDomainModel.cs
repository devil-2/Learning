using System;

namespace Domain.Models.Models
{
    public interface IDomainModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
