using Inventory_Tracker_Project.Enums.Catalog;
using Inventory_Tracker_Project.Models.Catalog;
using Inventory_Tracker_Project.Repositories.Catalog;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;

namespace Inventory_Tracker_Project_Tests.Repositories
{
    internal class CatalogRepositoryTests
    {
        private readonly CatalogItem _item = new CatalogItem(
            CatalogItemType.Card,
            "Test set",
            "Test card",
            "Test edition",
            DateTime.Now,
            3);

        private Mock<IMongoCollection<CatalogItem>> _mockCollection;
        private Mock<IMongoDatabase> _mockDatabase;
        private CatalogRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _mockCollection = new Mock<IMongoCollection<CatalogItem>>();
            _mockDatabase = new Mock<IMongoDatabase>();

            _mockDatabase.Setup(x => x.GetCollection<CatalogItem>(It.IsAny<string>(), null)).Returns(_mockCollection.Object);

            _repository = new CatalogRepository(_mockDatabase.Object);
        }

        [Test]
        public async Task GetAsync_NoItems_ReturnsCollectionNoItems()
        {
            var mockAsyncCursor = new Mock<IAsyncCursor<CatalogItem>>();
            mockAsyncCursor.Setup(x => x.MoveNext(default)).Returns(false);
            mockAsyncCursor.Setup(x => x.Current).Returns(new List<CatalogItem>());

            _mockCollection.Setup(x =>
            x.FindAsync(
                It.IsAny<FilterDefinition<CatalogItem>>(),
                It.IsAny<FindOptions<CatalogItem, CatalogItem>>(),
                default))
                .Returns(Task.FromResult(mockAsyncCursor.Object));

            var result = await _repository.GetAsync();
            result = result.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task GetAsync_HasItems_ReturnsCollectionItems()
        {
            var mockAsyncCursor = new Mock<IAsyncCursor<CatalogItem>>();
            mockAsyncCursor.SetupSequence(x => x.MoveNext(default)).Returns(true).Returns(false);
            mockAsyncCursor.Setup(x => x.Current).Returns(new List<CatalogItem> { _item });

            _mockCollection.Setup(x =>
            x.FindAsync(
                It.IsAny<FilterDefinition<CatalogItem>>(),
                It.IsAny<FindOptions<CatalogItem, CatalogItem>>(),
                default))
            .Returns(Task.FromResult(mockAsyncCursor.Object));

            var result = await _repository.GetAsync();
            result = result.ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result, Does.Contain(_item));
        }

        [Test]
        public async Task InsertAsync_NoItem()
        {
            await _repository.InsertItemAsync(null!);
            _mockCollection.Verify(x => x.InsertOneAsync(_item, null, default), Times.Never());
        }

        [Test]
        public async Task InsertAsync_HasItem()
        {
            await _repository.InsertItemAsync(_item);
            _mockCollection.Verify(x => x.InsertOneAsync(_item, null, default), Times.Once());
        }
    }
}
