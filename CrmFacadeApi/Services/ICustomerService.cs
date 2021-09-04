using System.Threading;
using System.Threading.Tasks;
using CrmFacadeApi.Models;
using CrmFacadeApi.Controllers;
using System.Collections.Generic;

namespace CrmFacadeApi.Services
{
    public interface ICustomerService
    {
        Response ValidCustomer(Customer customer);
    }
}