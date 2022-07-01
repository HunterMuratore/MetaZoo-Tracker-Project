using Inventory_Tracker_Project.Controllers;
using Inventory_Tracker_Project.Enums;
using Inventory_Tracker_Project.Interfaces;
using Inventory_Tracker_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Inventory_Tracker_Project_Tests.Controllers
{
    public class InventoryControllerTests
    {
        private readonly MetaZooItem _item = new MetaZooItem(
            MetaZooItemType.Card,
            "Test card",
            "Test edition",
            DateTime.Now,
            3);

        private Mock<IInventoryRepository> _mockRepository;
        private InventoryController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IInventoryRepository>();

            _controller = new InventoryController(_mockRepository.Object);
        }

        [Test]
        public void GetItems_NoItems_ReturnsOkNoItems()
        {
            var expectedItems = new List<MetaZooItem>();

            _mockRepository.Setup(x => x.Get()).Returns(expectedItems);

            var result = _controller.GetItems();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.That(okObjectResult.Value, Is.EqualTo(expectedItems));
        }

        [Test]
        public void GetItems_HasItem_ReturnsOkWithItem()
        {
            var expectedItems = new List<MetaZooItem> { _item };

            _mockRepository.Setup(x => x.Get()).Returns(expectedItems);

            var result = _controller.GetItems();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.That(okObjectResult.Value, Is.EqualTo(expectedItems));
        }

        [Test]
        public void AddItem_NoItem_ReturnsBadRequestNoItem()
        {
            var result = _controller.AddItem(null);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

            _mockRepository.Verify(x => x.InsertItem(_item), Times.Never());
        }
        
        [Test]
        public void AddItem_HasItem_ReturnsInsertItemOk()
        {
            _controller.AddItem(_item);
            _mockRepository.Verify(x => x.InsertItem(_item), Times.Once());
        }
    }
}