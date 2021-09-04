using CrmFacadeApi.Services;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Reference unit test implementation.
/// </summary>
namespace CrmFacadeApi.Tests
{
    public class HealthCheckServiceTests
    {
        [Fact]
        public async Task VerifyFakeHealthyResult()
        {
            var sut = new HealthCheckService();
            var result = await sut.IsHealthyAsync(new CancellationToken());
            Assert.True(result);
        }
    }
}
