using Domain.Models.Models;

namespace Domain.Models.Exceptions
{

    public class StatusPendingException<T> : BaseException<T> where T : BaseDomainModel
    {
        public StatusPendingException(T model) : base(model)
        {
        }
   
        public override string ToString()
        {
            return $"{nameof(T)} : [{Model.Name}] Status is Pending .{ContactAdmin}";
        }
    }
}
