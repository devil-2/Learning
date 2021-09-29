using Domain.Models.Enumerations;

namespace Domain.Models.Models
{
    public interface IModelStatus
    {
        Status ModelStatus { get; set; }
    }
}
