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

            _mockDatabase.Setup(x => x.GetCollection<MetaZooItem>(It.IsAny<string>(), null)).Returns();

            _repository = new InventoryRepository(_mockDatabase.Object);
        }
    }
}
