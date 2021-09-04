using System.Threading;
using System.Threading.Tasks;
using CrmFacadeApi.Models;
using CrmFacadeApi.Controllers;
using System.Collections.Generic;

using System.Net;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;


//using CrmFacadeApi.Domain.Services;
//using CrmFacadeApi.Domain.Repositories;


namespace CrmFacadeApi.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;

        private readonly IAddressVerificationService _addressVerificationService;

        public CustomerService(ILogger<CustomerService> logger, IAddressVerificationService addressVerificationService)
        {
            _addressVerificationService = addressVerificationService;
            _logger = logger;
        }

        
        public Response ValidCustomer(Customer customer)
        {

            Response response = new Response();
            response.Success = false;

            response.Success = _addressVerificationService.IsValidAddress(customer.Address);

            if (!response.Success)
            {
                customer.Address = null;
            }
            
            response.Customer = customer;
            
            return response;
        }

    }
}