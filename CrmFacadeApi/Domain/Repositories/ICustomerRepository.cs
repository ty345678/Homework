using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmFacadeApi.Models;

namespace CrmFacadeApi.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListCustomers();

    }
}
