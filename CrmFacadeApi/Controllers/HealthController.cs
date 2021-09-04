using CrmFacadeApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Reference controller implementation.
/// </summary>
namespace CrmFacadeApi.Controllers
{
    [ApiController]
    [Route("/health")]
    public class HealthController : ControllerBase
    {
        private readonly IHealthCheckService _healthCheckService;
        private readonly ILogger<HealthController> _logger;

        public HealthController(IHealthCheckService healthCheckService, ILogger<HealthController> logger)
        {
            _healthCheckService = healthCheckService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealth(CancellationToken cancellationToken)
        {
            var isHealthy = await _healthCheckService.IsHealthyAsync(cancellationToken);
            _logger.LogTrace($"Result:{isHealthy}");

            if (isHealthy)
            {
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
