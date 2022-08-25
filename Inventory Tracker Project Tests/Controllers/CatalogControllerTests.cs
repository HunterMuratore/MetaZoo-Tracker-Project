using Inventory_Tracker_Project.Controllers;
using Inventory_Tracker_Project.Enums.Catalog;
using Inventory_Tracker_Project.Interfaces.Repositories;
using Inventory_Tracker_Project.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Inventory_Tracker_Project_Tests.Controllers
{
    public class CatalogControllerTests
    {
        private readonly CatalogItem _item = new CatalogItem(
            CatalogItemType.Card,
            "Test card",
            "Test edition",
            DateTime.Now,
            3);

        private Mock<ICatalogRepository> _mockRepository;
        private CatalogController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<ICatalogRepository>();

            _controller = new CatalogController(_mockRepository.Object);
        }

        [Test]
        public async Task GetItemsAsync_NoItems_ReturnsOkNoItems()
        {
            var expectedItems = new List<CatalogItem>();

            _mockRepository.Setup(x => x.GetAsync()).Returns(Task.FromResult((IEnumerable<CatalogItem>)expectedItems));

            var result = await _controller.GetItemsAsync();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.That(okObjectResult.Value, Is.EqualTo(expectedItems));
        }

        [Test]
        public async Task GetItemsAsync_HasItem_ReturnsOkWithItem()
        {
            var expectedItems = new List<CatalogItem> { _item };

            _mockRepository.Setup(x => x.GetAsync()).Returns(Task.FromResult((IEnumerable<CatalogItem>)expectedItems));

            var result = await _controller.GetItemsAsync();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.That(okObjectResult.Value, Is.EqualTo(expectedItems));
        }

        [Test]
        public async Task AddItemAsync_NoItem_ReturnsBadRequestNoItem()
        {
            Assert.IsInstanceOf<BadRequestObjectResult>(await _controller.AddItemAsync(null));

            _mockRepository.Verify(x => x.InsertItemAsync(_item), Times.Never());
        }

        [Test]
        public async Task AddItemAsync_HasItem_ReturnsInsertItemOk()
        {
            await _controller.AddItemAsync(_item);
            _mockRepository.Verify(x => x.InsertItemAsync(_item), Times.Once());
        }
    }
}