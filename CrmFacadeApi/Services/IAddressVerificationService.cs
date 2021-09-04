using CrmFacadeApi.Models;

namespace CrmFacadeApi.Services
{
    public interface IAddressVerificationService
    {
        bool IsValidAddress(Address address);
    }
}
