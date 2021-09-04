using CrmFacadeApi.Models;
using System;


namespace CrmFacadeApi.Repository
{

    public class CrmRepository : ICrmRepository
    {

        public bool UpsertCustomer(Customer customer)
        {
            //TODO, Data Storage
            try
            {
                var jsonString = "";

                if (customer.Address == null)
                {
                    BadCustomer badCustomer = new BadCustomer();
                    badCustomer.CustomerName = customer.CustomerName;
                    badCustomer.CustomerEmail = customer.CustomerEmail;
                    jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(badCustomer);
                }
                else { jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(customer); }

                Console.WriteLine(jsonString);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e}");
                return false;
            }
        }
        

    }
}
