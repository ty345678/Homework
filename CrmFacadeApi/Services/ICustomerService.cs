using CrmFacadeApi.Models;

namespace CrmFacadeApi.Services
{
    public interface ICustomerService
    {
        Response ValidCustomer(Customer customer);
    }
}