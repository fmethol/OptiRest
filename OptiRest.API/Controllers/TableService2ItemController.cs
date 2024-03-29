﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;

namespace OptiRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableService2ItemController : ControllerBase
    {
        private readonly ITableService2ItemService _tableService2ItemService;

        public TableService2ItemController(ITableService2ItemService tableService2ItemService)
        {
            _tableService2ItemService = tableService2ItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTableService2Item(TableService2ItemDto tableService2ItemDto)
        {
            var tableService2Item = await _tableService2ItemService.AddTableService2Item(tableService2ItemDto);
            return Ok(tableService2Item);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTableService2Item(TableService2ItemDto tableService2ItemDto)
        {
            var tableService2Item = await _tableService2ItemService.UpdateTableService2Item(tableService2ItemDto);
            return Ok(tableService2Item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableService2Item(int id)
        {
            var tableService2Item = await _tableService2ItemService.DeleteTableService2Item(id);
            return Ok(tableService2Item);
        }

        [HttpDelete("byTableServiceIdAndItemId")]
        public async Task<IActionResult> DeleteTableService2ItemByTableServiceIdAndItemId(int tableServiceId, int itemId)
        {
            var tableService2Item = await _tableService2ItemService.DeleteTableService2ItemByTableServiceIdAndItemId(tableServiceId, itemId);
            return Ok(tableService2Item);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableService2Item(int id)
        {
            var tableService2Item = await _tableService2ItemService.GetTableService2Item(id);
            return Ok(tableService2Item);
        }

        [HttpGet("byTableService/")]
        public async Task<IActionResult> GetTableService2Items(int tableServiceId)
        {
            var tableService2Items = await _tableService2ItemService.GetTableService2Items(tableServiceId);
            return Ok(tableService2Items);
        }

        [HttpGet("allItems/")]
        public async Task<IActionResult> GetAllItems(int tenantId)
        {
            var tableService2Items = await _tableService2ItemService.GetAllItems(tenantId);
            return Ok(tableService2Items);
        }

        [HttpGet("inProgressItems/")]
        public async Task<IActionResult> GetInProgressItems(int tenantId)
        {
            var tableService2Items = await _tableService2ItemService.GetInProgressItems(tenantId);
            return Ok(tableService2Items);
        }

        [HttpGet("inProgressItemsByKitchen/")]
        public async Task<IActionResult> GetInProgressItemsbyKitchen(int kitchenId)
        {
            var tableService2Items = await _tableService2ItemService.GetInProgressItemsbyKitchen(kitchenId);
            return Ok(tableService2Items);
        }
    }
}
