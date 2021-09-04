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
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(customer);

                Console.WriteLine(jsonString);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e}");
                return false;
            }
        }
        public bool UpsertCustomer(BadCustomer customer)
        {
            //TODO, Data Storage
            try
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(customer);

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
