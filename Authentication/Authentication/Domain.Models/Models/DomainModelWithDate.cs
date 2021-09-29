using Domain.Models.Enumerations;
using System;

namespace Domain.Models.Models
{
    public class DomainModelWithDate : BaseDomainModel, IModelDate, IModelStatus
    {
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset ValidTill { get; set; }
        public Status ModelStatus { get; set; }
    }
}
