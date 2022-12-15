using DAL.EF;
using DAL.Entity;
using DAL.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Test
{
    class TestGoodRepository
        : BaseRepository<Good>
    {
        public TestGoodRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryTest
    {
        [Fact]
        public void Create_Good_CallAddMethodOfDBSetWithGood()
        {
            var options = new DbContextOptionsBuilder<GoodContext>().Options;
            var mockContext = new Mock<GoodContext>(options);
            var mockDbSet = new Mock<DbSet<Good>>();
            mockContext.Setup(context => context.Set<Good>()).Returns(mockDbSet.Object);

            var repository = new TestGoodRepository(mockContext.Object);

            Good expected = new Mock<Good>().Object;

            repository.Create(expected);

            mockDbSet.Verify(dbSet => dbSet.Add(expected), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            var options = new DbContextOptionsBuilder<GoodContext>().Options;
            var mockContext = new Mock<GoodContext>(options);
            var mockDbSet = new Mock<DbSet<Good>>();
            mockContext.Setup(context => context.Set<Good>()).Returns(mockDbSet.Object);
       
            var repository = new TestGoodRepository(mockContext.Object);

            Good expected = new Good() { Id = 4, StorageId = 1, Amount = 121, TypeId = 1 };
            mockDbSet.Setup(mock => mock.Find(expected.Id)).Returns(expected);

            repository.Delete(expected.Id);

            mockDbSet.Verify(dbSet => dbSet.Find(expected.Id), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expected), Times.Once());
        }


        [Fact]
        public void Get_Good_CalledFindMethodOfDBSetWithCorrectId()
        {
            var options = new DbContextOptionsBuilder<GoodContext>().Options;
            var mockContext = new Mock<GoodContext>(options);
            var mockDbSet = new Mock<DbSet<Good>>();
            mockContext.Setup(context => context.Set<Good>()).Returns(mockDbSet.Object);

            Good expected = new Good() { Id = 3, StorageId=1, Amount=999, TypeId=5 };
            mockDbSet.Setup(mock => mock.Find(expected.Id)).Returns(expected);
            var repository = new TestGoodRepository(mockContext.Object);

            Good actual = repository.Get(expected.Id);

            mockDbSet.Verify(dbSet => dbSet.Find( expected.Id), Times.Once());
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_Good_CalledFindMethodOfDBSetWithNotCorrectId()
        {
            var options = new DbContextOptionsBuilder<GoodContext>().Options;
            var mockContext = new Mock<GoodContext>(options);
            var mockDbSet = new Mock<DbSet<Good>>();
            mockContext.Setup(context => context.Set<Good>()).Returns(mockDbSet.Object);

            Good expected = new Good() { Id = 1, StorageId = 3, Amount = 54, TypeId = 2 };
            mockDbSet.Setup(mock => mock.Find(expected.Id)).Returns(expected);
            var repository = new TestGoodRepository(mockContext.Object);

            Good actual = repository.Get(2);

            mockDbSet.Verify(dbSet => dbSet.Find(2), Times.Once());
            Assert.NotEqual(expected, actual);
        }

    }
}
