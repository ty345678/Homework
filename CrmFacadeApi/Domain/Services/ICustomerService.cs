using System.Threading;
using System.Threading.Tasks;
using CrmFacadeApi.Models;
using CrmFacadeApi.Controllers;
using System.Collections.Generic;

namespace CrmFacadeApi.Domain.Services
{
    public interface ICustomerService
    {
        //Task<Response> IsValidAddress(Address address);

       // Task<Response> ValidCustomer(Customer customer);




        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        Task<IEnumerable<Customer>> ListCustomer();
    }
}