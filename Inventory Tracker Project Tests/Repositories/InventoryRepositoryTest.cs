using Inventory_Tracker_Project.Enums;
using Inventory_Tracker_Project.Interfaces;
using Inventory_Tracker_Project.Models;
using Inventory_Tracker_Project.Repositories;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Tracker_Project_Tests.Repositories
{
    internal class InventoryRepositoryTest
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

            _mockDatabase.Setup(x => x.GetCollection<MetaZooItem>()).Returns();

            _repository = new InventoryRepository(_mockDatabase.Object);
        }
    }
}
