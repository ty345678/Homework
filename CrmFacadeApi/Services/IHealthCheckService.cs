using System.Threading;
using System.Threading.Tasks;

namespace CrmFacadeApi.Services
{
    public interface IHealthCheckService
    {
        Task<bool> IsHealthyAsync(CancellationToken token);
    }
}