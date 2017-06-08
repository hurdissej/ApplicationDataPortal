using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    public class PromotionsRepositoryTests
    {
        public PromotionsRepository _repository;
        public Mock<DbSet<Promotions>> _mockPromotions;

        [TestInitialize]
        public void Initialize()
        {
            _mockPromotions = new Mock<DbSet<Promotions>>();
            
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(p => p.Promotions).Returns(_mockPromotions.Object);

            _repository = new PromotionsRepository(mockContext.Object);

        }

        [TestMethod]
        public void GetPromotions_PromotionsExist_ExpectedResult()
        {
            var promotion = new Promotions();

            _mockPromotions.SetSource(new[] { promotion });
            _mockPromotions.Setup(m => m.Include("DisplayTypes")).Returns(_mockPromotions.Object);

            var result = _repository.GetPromotions();

            result.Should().Contain(promotion);

        }

        [TestMethod]
        public void GetPromotion_PromotionRequestedDoesntExist_NothingReturned()
        {
            var promotion = new Promotions(){Id = 1};
            var promotion2 = new Promotions(){Id = 2};

            _mockPromotions.SetSource(new[] { promotion, promotion2 });
            _mockPromotions.Setup(m => m.Include("DisplayTypes")).Returns(_mockPromotions.Object);

            var result = _repository.GetPromotion(3);

            result.Should().BeNull();
        }

        [TestMethod]
        public void GetPromotion_PromotionsRequested_ReturnsCorrectPromotion()
        {
            var promotion = new Promotions() { Id = 1 };
            var promotion2 = new Promotions() { Id = 2 };

            _mockPromotions.SetSource(new[] { promotion, promotion2 });
            _mockPromotions.Setup(m => m.Include("DisplayTypes")).Returns(_mockPromotions.Object);

            var result = _repository.GetPromotion(2);

            result.Should().Be(promotion2);
        }

        [TestMethod]
        public void GetNumberOfPromotionsWithDT_DisplayTypeProvided_IntReturned()
        {
            var promotion = new Promotions() { Id = 1, DisplayTypesId = 1};
            var promotion2 = new Promotions() { Id = 2, DisplayTypesId = 1};

            _mockPromotions.SetSource(new[] { promotion, promotion2 });
            _mockPromotions.Setup(m => m.Include("DisplayTypes")).Returns(_mockPromotions.Object);

            var result = _repository.GetNumberOfPromotionsOnDisplayType(1);

            result.Should().Be(2);
        }

    }
}
