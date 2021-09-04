using CrmFacadeApi.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Xml.Linq;

namespace CrmFacadeApi.Services
{

    public class AddressVerificationService : IAddressVerificationService
    {

        private readonly ILogger<AddressVerificationService> _logger;
        public AddressVerificationService(ILogger<AddressVerificationService> logger)
        {
            _logger = logger;
        }



        public bool IsValidAddress(Address address)
        {
            bool validResponse = false;
            XDocument requestDoc = new XDocument(
                new XElement("AddressValidateRequest",
                    new XAttribute("USERID", "163MINIT5981"),
                    new XElement("Revision", "1"),
                    new XElement("Address",
                        new XAttribute("ID", "0"),
                        new XElement("Address1", address.Line1),
                        new XElement("Address2", ""),
                        new XElement("City", address.City),
                        new XElement("State", address.State),
                        new XElement("Zip5", address.PostalCode),
                        new XElement("Zip4", "")
                        )));
            try
            {
                var url = "http://production.shippingapis.com/ShippingAPI.dll?API=Verify&XML=" + requestDoc;
                var client = new WebClient();
                var response = client.DownloadString(url);
                var xdoc = XDocument.Parse(response.ToString());

                //_logger.LogInformation($"{xdoc}");

                foreach (XElement element in xdoc.Descendants("Address"))
                {
                    if (element.Element("Error") == null)
                    {
                        validResponse = true;
                    }

                }
            }
            catch (WebException e)
            {
                _logger.LogError($"Failed Retreving Valid Address {e}");

                validResponse = false;
            }
            return validResponse;

        }

        public static string GetXMLElement(XElement element, string name)
        {
            var el = element.Element(name);
            if (el != null)
            {
                return el.Value;
            }
            return "";
        }

    }
}



