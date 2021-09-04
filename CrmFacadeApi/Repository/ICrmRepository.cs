using CrmFacadeApi.Models;

namespace CrmFacadeApi.Repository
{

    public interface ICrmRepository
    {
        bool UpsertCustomer(Customer customer);
        bool UpsertCustomer(BadCustomer customer);
    }
}
