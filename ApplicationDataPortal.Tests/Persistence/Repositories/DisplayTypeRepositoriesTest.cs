using System;
using System.Collections.Generic;
using System.Data.Entity;
using ApplicationDataPortal.Core.Models;
using ApplicationDataPortal.Core.Models.AccountModels;
using ApplicationDataPortal.Repositories;
using ApplicationDataPortal.Tests.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ApplicationDataPortal.Tests.Persistence.Repositories
{
    [TestClass]
    public class DisplayTypeRepositoriesTest
    {
        private DisplayTypesRepositories _repository;
        private Mock<DbSet<DisplayTypes>> _mockDisplayTypes;
        private Mock<DbSet<Customer>> _mockCustomers;

        [TestInitialize]
        public void initialiaze()
        {
            _mockDisplayTypes = new Mock<DbSet<DisplayTypes>>();
            _mockCustomers = new Mock<DbSet<Customer>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(d => d.DisplayTypes).Returns(_mockDisplayTypes.Object);
            
            _repository = new DisplayTypesRepositories(mockContext.Object);
        }


        [TestMethod]
        public void GetDisplayTypes_MethodCalled_ReturnsDisplayTypes()
        {

            var displayType = new DisplayTypes() {};

            _mockDisplayTypes.SetSource(new [] { displayType });
            _mockDisplayTypes.Setup(m => m.Include("Customer")).Returns(_mockDisplayTypes.Object);

            var displayTypes = _repository.GetDisplayTypes();

            displayTypes.Should().Contain(displayType);

        }

        [TestMethod]
        public void GetDisplayType_DisplayTypeDoesntExist_NothingReturned()
        {
            var displayType = new DisplayTypes() {Id = 1};
            var displayType2 = new DisplayTypes() {Id = 2};

            _mockDisplayTypes.SetSource(new[] { displayType, displayType2 });
            _mockDisplayTypes.Setup(m => m.Include("Customer")).Returns(_mockDisplayTypes.Object);

            var displayTypes = _repository.GetDisplayType(3);

            displayTypes.Should().BeNull();
        }

        [TestMethod]
        public void GetDisplayType_DisplayTypeProvided_CorrectDisplayTypeReturned()
        {
            var displayType = new DisplayTypes() { Id = 1 };
            var displayType2 = new DisplayTypes() { Id = 2 };

            _mockDisplayTypes.SetSource(new[] { displayType, displayType2 });
            _mockDisplayTypes.Setup(m => m.Include("Customer")).Returns(_mockDisplayTypes.Object);

            var displayTypes = _repository.GetDisplayType(2);

            displayTypes.Should().Be(displayType2);
        }

        // To Do - add Create and Update Tests in
    }
}
