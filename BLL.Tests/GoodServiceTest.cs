using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.Entity;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    public class GoodServiceTest
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new GoodService(nullUnitOfWork));
        }

        [Fact]
        public void GetGood_FromDAL_CorrectMappingToDTO()
        {
            var goodService = GetGoodService();

            var actual = goodService.GetGoods(1, 0).First();

            Assert.True(
                actual.Id == 1
                && actual.TypeId == 2
                && actual.StorageId == 2
                && actual.Amount == 1
                );
        }

        IGoodService GetGoodService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expected = new Good() { Id = 1,  Amount = 1, StorageId = 2, TypeId = 2 };
            var mockDbSet = new Mock<IGoodRepository>();
            mockDbSet.Setup(e => e.Find(It.IsAny<Func<Good, bool>>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(
                    new List<Good>() { expected }
                    );
            mockContext.Setup(context => context.Goods).Returns(mockDbSet.Object);

            IGoodService goodService = new GoodService(mockContext.Object);

            return goodService;
        }
    }
}
