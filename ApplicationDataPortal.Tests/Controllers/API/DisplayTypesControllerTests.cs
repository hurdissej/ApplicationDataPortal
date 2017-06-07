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
    public class DisplayTypesControllerTests
    {
        private DisplayTypesController _controller;
        private Mock<IDisplayTypesRepositories> _mockRepository;

        [TestInitialize]
        public void testInitialize()
        {
            _mockRepository = new Mock<IDisplayTypesRepositories>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.DisplayTypes).Returns(_mockRepository.Object);

            _controller = new DisplayTypesController(mockUoW.Object);
        }

        [TestMethod]
        public void DeleteDisplayType_NoDisplayTypeExists_ShouldReturnBadRequest()
        {
            var result = _controller.DeleteDisplayType(1);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void DeleteDisplayType_DeleteDisplayType_ShouldReturnok()
        {
            var displayType = new DisplayTypes();

            _mockRepository.Setup(r => r.GetDisplayType(1)).Returns(displayType);

            var result = _controller.DeleteDisplayType(1);

            result.Should().BeOfType<OkResult>();

        }

        [TestMethod]
        public void UpdateDisplayType_NoDisplayTypeExists_ShouldReturnBadRequest()
        {
            var displaytypeDto = new DisplayTypeDto();
            var result = _controller.UpdateDisplayType(1, displaytypeDto);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void UpdateDisplayType_DeleteDisplayType_ShouldReturnok()
        {

            var displaytypeDto = new DisplayTypeDto();
            var displayType = new DisplayTypes();

            _mockRepository.Setup(r => r.GetDisplayType(1)).Returns(displayType);

            var result = _controller.UpdateDisplayType(1, displaytypeDto);

            result.Should().BeOfType<OkResult>();

        }

        [TestMethod]
        public void GetDisplayTypes_APICalled_GetListOfDisplayTypes()
        {
            var result = _controller.GetDisplayTypes();

            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<DisplayTypeDto>>>();

        }

        [TestMethod]
        public void GetDisplayType_DisplayTypeDoesntExist_returnBadRequest()
        {
            var result = _controller.GetDisplayType(1);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void GetDisplayType_DisplayTypeProvided_GetDisplayType()
        {
            var displayType = new DisplayTypes();

            _mockRepository.Setup(r => r.GetDisplayType(1)).Returns(displayType);

            var result = _controller.GetDisplayType(1);

            result.Should().BeOfType<OkNegotiatedContentResult<DisplayTypes>>();
        }

    }
}
