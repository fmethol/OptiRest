﻿using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Context;
using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;


namespace OptiRest.Service.Services
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _db;

        public ItemService(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<ItemDto> CreateItem(ItemDto itemDto)
        {
            if (itemDto == null)
            {
                return null;
            }

            var item = new Item
            {
                TenantId = itemDto.TenantId,
                Code = itemDto.Code,
                ItemCategoryId = itemDto.ItemCategoryId,
                KitchenId = itemDto.KitchenId,
                Title = itemDto.Title,
                Summary = itemDto.Summary,
                Price = itemDto.Price,
                Active = itemDto.Active
            };

            await _db.AddAsync(item);
            await _db.SaveChangesAsync();

            itemDto.Id = item.Id;
            
            return itemDto;

        }

        public async Task<int> DeleteItem(int id)
        {
            var item = await _db.Items.FirstOrDefaultAsync(c => c.Id == id);

            if (item == null)
            {
                return 0;
            }

            _db.Items.Remove(item);
            await _db.SaveChangesAsync();

            return item.Id;

        }

        public async Task<ItemDto> GetItem(int id)
        {
            var item = _db.Items.FirstOrDefault(p => p.Id == id);

            var itemDto = new ItemDto
            {
                Id = item.Id,
                TenantId = item.TenantId,
                Code = item.Code,
                ItemCategoryId = item.ItemCategoryId,
                KitchenId = item.KitchenId,
                Title = item.Title,
                Summary = item.Summary,
                Price = item.Price,
                Active = item.Active
            };

            return await Task.FromResult(itemDto);

        }

        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = await _db.Items
                .Select(p => new ItemDto
                {
                    Id = p.Id,
                    TenantId = p.TenantId,
                    Code = p.Code,
                    ItemCategoryId = p.ItemCategoryId,
                    KitchenId = p.KitchenId,
                    Title = p.Title,
                    Summary = p.Summary,
                    Price = p.Price,
                    Active = p.Active
                })
                .ToListAsync();

            return items;
        }

        public async Task<ItemDto> UpdateItem(ItemDto request)
        {
            var item = await _db.Items.FirstOrDefaultAsync(c => c.Id == request.Id);

            if (item == null)
            {
                return null;
            }

            item.TenantId = request.TenantId;
            item.Code = request.Code;
            item.ItemCategoryId = request.ItemCategoryId;
            item.KitchenId = request.KitchenId;
            item.Summary = request.Summary;
            item.Price = request.Price;
            item.Active = request.Active;

            await _db.SaveChangesAsync();

            return request;

        }
    }
}
