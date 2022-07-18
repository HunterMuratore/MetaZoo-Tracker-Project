﻿using Inventory_Tracker_Project.Interfaces;
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
        public async Task<IActionResult> GetItemsAsync()
        {
            var items = await _inventoryRepository.GetAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody] MetaZooItem? item)
        {
            if (item == default)
            {
                return BadRequest("Body cannot be empty.");
            }

            await _inventoryRepository.InsertItemAsync(item);
            return Ok();
        }
    }
}