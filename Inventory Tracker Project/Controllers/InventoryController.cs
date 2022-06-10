using Inventory_Tracker_Project.Models;
using Inventory_Tracker_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Tracker_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepository _inventoryRepository;
        public InventoryController(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_inventoryRepository.Get());
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] MetaZooItem item)
        {
            _inventoryRepository.InsertItem(item);
            return Ok();
        }
    }
}
