using AutoMapper;
using ERP_API.DTOs;
using ERP_API.Models;
using ERP_API.Repositories.Interfaces;
using ERP_API.Services.Implementations;
using ERP_API.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace ERP_API_TESTS
{
    [TestClass]
    public class CustomerTests
    {
        #region private members

        private ICustomerService _testService;
        private Mock<ICustomerRepository> _mockICustomerRepository;
        private Mock<IMapper> _mockMapper;

        #endregion private members

        #region test start & finish

        [TestInitialize]
        public void Setup()
        {
            _mockMapper = new Mock<IMapper>();

            _mockICustomerRepository = new Mock<ICustomerRepository>();
            _mockMapper.Setup(x => x.Map<Customer>(It.IsAny<CustomerDTO>()))
               .Returns(new Customer()
               {
                   CustomerName = "testname"
               });

            _testService = new CustomerService(
                _mockICustomerRepository.Object,
                _mockMapper.Object);
        }

        [TestCleanup]
        public void VerifyNoOtherCalls()
        {
            _mockICustomerRepository.VerifyNoOtherCalls();
        }

        #endregion test start & finish

        [TestMethod]
        [TestCategory("Success")]
        public void AddCustomer_SuccessTest()
        {
            // prepare
            var customerDto = new CustomerDTO()
            {
                CustomerName = "testname"
            };

            var customerId = 1;

            _ = _mockICustomerRepository
                    .Setup(x => x.AddcustomerAsync(It.IsAny<Customer>()))
                    .ReturnsAsync(customerId);

            // execute
            _ = _testService.AddCustomerAsync(customerDto);

            // assert
            _mockICustomerRepository.Verify(x => x.AddcustomerAsync(It.IsAny<Customer>()), Times.Once);
            _mockMapper.Verify(x => x.Map<Customer>(It.IsAny<CustomerDTO>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Fail")]
        public async Task AddCustomer_EmptyPageInfo()
        {
            // execute + assert
            _ = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                () => _testService.AddCustomerAsync(null));
        }
    }
}