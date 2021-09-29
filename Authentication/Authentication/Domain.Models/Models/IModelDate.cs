using System;

namespace Domain.Models.Models
{
    public interface IModelDate
    {
         DateTimeOffset ValidFrom { get; set; }
         DateTimeOffset ValidTill { get; set; }
    }
   
}
