using Inventory_Tracker_Project.Interfaces.Repositories;
using Inventory_Tracker_Project.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Tracker_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsAsync()
        {
            var items = await _catalogRepository.GetAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody] CatalogItem? item)
        {
            if (item == default)
            {
                return BadRequest("Body cannot be empty.");
            }

            await _catalogRepository.InsertItemAsync(item);
            return Ok();
        }
    }
}