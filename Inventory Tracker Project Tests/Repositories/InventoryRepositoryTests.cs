using Inventory_Tracker_Project.Enums;
using Inventory_Tracker_Project.Models;
using Inventory_Tracker_Project.Repositories;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;

namespace Inventory_Tracker_Project_Tests.Repositories
{
    internal class InventoryRepositoryTests
    {
        private readonly MetaZooItem _item = new MetaZooItem(
            MetaZooItemType.Card,
            "Test card",
            "Test edition",
            DateTime.Now,
            3);

        private Mock<IMongoCollection<MetaZooItem>> _mockCollection;
        private Mock<IMongoDatabase> _mockDatabase;
        private InventoryRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _mockCollection = new Mock<IMongoCollection<MetaZooItem>>();
            _mockDatabase = new Mock<IMongoDatabase>();

            _mockDatabase.Setup(x => x.GetCollection<MetaZooItem>(It.IsAny<string>(), null)).Returns(_mockCollection.Object);

            _repository = new InventoryRepository(_mockDatabase.Object);
        }

        [Test]
        public async Task Get_NoItems_ReturnsCollectionNoItems()
        {
            var mockAsyncCursor = new Mock<IAsyncCursor<MetaZooItem>>();
            mockAsyncCursor.Setup(x => x.MoveNextAsync(default)).ReturnsAsync(true);
            mockAsyncCursor.Setup(x => x.Current).Returns(new List<MetaZooItem>());

            _mockCollection.Setup(x =>
            x.FindAsync(
                It.IsAny<FilterDefinition<MetaZooItem>>(),
                It.IsAny<FindOptions<MetaZooItem, MetaZooItem>>(),
                default))
                .Returns(Task.FromResult(mockAsyncCursor.Object));

            var result = await _repository.GetAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task Get_HasItems_ReturnsCollectionItems()
        {
            var mockAsyncCursor = new Mock<IAsyncCursor<MetaZooItem>>();
            mockAsyncCursor.Setup(x => x.MoveNextAsync(default)).ReturnsAsync(true);
            mockAsyncCursor.Setup(x => x.Current).Returns(new List<MetaZooItem> { _item });

            _mockCollection.Setup(x =>
            x.FindAsync(
                It.IsAny<FilterDefinition<MetaZooItem>>(),
                It.IsAny<FindOptions<MetaZooItem, MetaZooItem>>(),
                default))
                .Returns(Task.FromResult(mockAsyncCursor.Object));

            var result = await _repository.GetAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result, Does.Contain(_item));
        }

        [Test]
        public void InsertItems_NoItem()
        {
            _repository.InsertItem(null!);
            _mockCollection.Verify(x => x.InsertOne(_item, null, default), Times.Never());
        }

        [Test]
        public void InsertItems_HasItem()
        {
            _repository.InsertItem(_item);
            _mockCollection.Verify(x => x.InsertOne(_item, null, default), Times.Once());
        }
    }
}
