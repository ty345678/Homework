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

            if (_crmRepository.UpsertCustomer(result.Customer))
                return Ok();
            else
                return StatusCode(400); 
        }
    }
}
