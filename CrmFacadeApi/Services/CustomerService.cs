using CrmFacadeApi.Models;
using Microsoft.Extensions.Logging;



namespace CrmFacadeApi.Services
{
    public class CustomerService : ICustomerService
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
            //validates address via USPS address validation service
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