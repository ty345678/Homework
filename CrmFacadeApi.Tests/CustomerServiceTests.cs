using CrmFacadeApi.Models;
using CrmFacadeApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

/// <summary>
/// Unit testing for the CustomerSerivce results
/// Response result 
///     Success = true/false for valid address
///     Customer = returned responce with valid address
///                 if invalid address, address = null
/// </summary>
namespace CrmFacadeApi.Tests
{
    public class CustomerSerivceTests
    {
        
        [Fact]
        public void VerifyValid_True_CustomerResults()
        {
            Customer customer = new Customer();
            



            var mockIAddressVerificationService = new Mock<IAddressVerificationService>();
            var mockLogger = new Mock<ILogger<CustomerService>>();

            mockIAddressVerificationService.Setup(f => f.IsValidAddress(It.IsAny<Address>())).Returns(true);

            var sut = new CustomerService(mockLogger.Object, mockIAddressVerificationService.Object);
            var result =  sut.ValidCustomer(customer);
            Assert.True(result.Success);

        }
        [Fact]
        public void VerifyValid_True_ValidCustomer_CustomerResults()
        {
            Customer customer = new Customer();




            var mockIAddressVerificationService = new Mock<IAddressVerificationService>();
            var mockLogger = new Mock<ILogger<CustomerService>>();

            mockIAddressVerificationService.Setup(f => f.IsValidAddress(It.IsAny<Address>())).Returns(true);

            var sut = new CustomerService(mockLogger.Object, mockIAddressVerificationService.Object);
            var result = sut.ValidCustomer(customer);
            Assert.Equal(result.Customer,customer);

        }
        [Fact]
        public void VerifyValid_False_CustomerResults()
        {
            Customer customer = new Customer();




            var mockIAddressVerificationService = new Mock<IAddressVerificationService>();
            var mockLogger = new Mock<ILogger<CustomerService>>();

            mockIAddressVerificationService.Setup(f => f.IsValidAddress(It.IsAny<Address>())).Returns(false);

            var sut = new CustomerService(mockLogger.Object, mockIAddressVerificationService.Object);
            var result = sut.ValidCustomer(customer);
            Assert.False(result.Success);

        }
        [Fact]
        public void VerifyValid_False_NullAddress_CustomerResults()
        {
            Customer customer = new Customer();




            var mockIAddressVerificationService = new Mock<IAddressVerificationService>();
            var mockLogger = new Mock<ILogger<CustomerService>>();

            mockIAddressVerificationService.Setup(f => f.IsValidAddress(It.IsAny<Address>())).Returns(true);

            var sut = new CustomerService(mockLogger.Object, mockIAddressVerificationService.Object);
            var result = sut.ValidCustomer(customer);
            Assert.Null(result.Customer.Address);

        }

    }
}
