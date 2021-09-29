using BasicApplication.Domain.Enumerations;

namespace BasicApplication.Domain.Services
{
    public interface IDataServiceResponse {
        DBResponse Response { get; set; }
    }
}
