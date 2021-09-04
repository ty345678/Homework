using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Reference service implementation.
/// </summary>
namespace CrmFacadeApi.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        public async Task<bool> IsHealthyAsync(CancellationToken token)
        {
            await Task.Delay(500);
            return true;
        }
    }
}
