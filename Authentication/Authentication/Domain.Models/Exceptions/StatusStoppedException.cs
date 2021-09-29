using Domain.Models.Models;

namespace Domain.Models.Exceptions
{
    public class StatusStoppedException<T> : BaseException<T> where T : BaseDomainModel
    {
        public StatusStoppedException(T model) : base(model)
        {
        }

        public override string ToString()
        {
            return $"{nameof(T)} : [{Model.Name}] Status is Stopped .{ContactAdmin}";
        }
    }
}
