using CrmFacadeApi.Models;
using CrmFacadeApi.Repository;
using CrmFacadeApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CrmFacadeApi.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICrmRepository _crmRepository;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerSerivce, ICrmRepository crmRepository)
        {
            _crmRepository = crmRepository;
            _customerService = customerSerivce;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddCustomerController([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad Request");

            Response result = _customerService.ValidCustomer(customer);

            if (result.Customer.Address == null)
            {
                BadCustomer badCustomer = new BadCustomer();
                badCustomer.CustomerName = result.Customer.CustomerName;
                badCustomer.CustomerEmail = result.Customer.CustomerEmail;
                _crmRepository.UpsertCustomer(badCustomer);
                return Ok();
            }

            _crmRepository.UpsertCustomer(result.Customer);
            return Ok();
        }
    }
}
