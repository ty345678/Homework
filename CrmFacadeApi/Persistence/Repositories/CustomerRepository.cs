using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CrmFacadeApi.Persistence.Contexts;
using CrmFacadeApi.Domain.Repositories;
using CrmFacadeApi.Models;

namespace CrmFacadeApi.Persistence.Repositories
{
    public class CustomerRepository: BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> ListCustomers()
        {
            return await _context.Customers.();
        }



    }
}
