
namespace CrmFacadeApi.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class BadCustomer
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
