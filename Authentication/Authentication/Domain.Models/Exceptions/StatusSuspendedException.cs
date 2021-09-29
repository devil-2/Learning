using Domain.Models.Models;

namespace Domain.Models.Exceptions
{
    public class StatusSuspendedException<T> : BaseException<T> where T : BaseDomainModel
    {
        public StatusSuspendedException(T model) : base(model)
        {
        }

        public override string ToString()
        {
            return $"{nameof(T)} : [{Model.Name}] Status is Suspended .{ContactAdmin}";
        }
    }
}
