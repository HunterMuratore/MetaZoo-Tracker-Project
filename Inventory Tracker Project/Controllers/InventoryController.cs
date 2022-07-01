using Inventory_Tracker_Project.Interfaces;
using Inventory_Tracker_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Tracker_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_inventoryRepository.Get());
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] MetaZooItem? item)
        {
            if (item == default)
            {
                return BadRequest("Body cannot be empty.");
            }

            _inventoryRepository.InsertItem(item);
            return Ok();
        }
    }
}