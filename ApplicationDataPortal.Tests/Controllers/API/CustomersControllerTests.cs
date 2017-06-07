using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using ApplicationDataPortal.Controllers.API;
using ApplicationDataPortal.Core;
using ApplicationDataPortal.Core.Models;
using ApplicationDataPortal.Core.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ApplicationDataPortal.Tests.Controllers.API
{
    [TestClass]
    public class CustomersControllerTests
    {
        private Mock<ICustomersRepository> _mockRepository;
        private CustomersController _controller;

        [TestInitialize]
        public void testInitialize()
        {
            _mockRepository = new Mock<ICustomersRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Customers).Returns(_mockRepository.Object);
            
            _controller = new CustomersController(mockUoW.Object);
        }

        [TestMethod]
        public void getCustomer_CustomerProvided_ReturnsCustomer()
        {
            var customer  = new Customer();

            _mockRepository.Setup(r => r.GetCustomer(1)).Returns(customer);

            var result = _controller.GetCustomer(1);

            result.Should().BeOfType<OkNegotiatedContentResult<Customer>>();
        }

        [TestMethod]
        public void getCustomers_APICalled_CustomersReturned()
        {
            var result = _controller.GetCustomers();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<Customer>>>();
        }

        [TestMethod]
        public void GetCustomer_CustomerDoesNotExist_BadRequest()
        {
            var result = _controller.GetCustomer(1);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

    }
}
