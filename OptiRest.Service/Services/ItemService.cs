using Microsoft.EntityFrameworkCore;
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
                tenantId = itemDto.tenantId,
                code = itemDto.code,
                categoryId = itemDto.categoryId,
                kitchenId = itemDto.kitchenId,
                title = itemDto.title,
                summary = itemDto.summary,
                price = itemDto.price,
                active = itemDto.active
            };

            await _db.AddAsync(item);
            await _db.SaveChangesAsync();

            itemDto.id = item.id;

            return itemDto;

        }

        public async Task<int> DeleteItem(int id)
        {
            var item = await _db.Items.FirstOrDefaultAsync(c => c.id == id);

            if (item == null)
            {
                return 0;
            }

            _db.Items.Remove(item);
            await _db.SaveChangesAsync();

            return item.id;

        }

        public async Task<ItemDto> GetItem(int id)
        {
            var item = _db.Items.FirstOrDefault(p => p.id == id);

            var itemDto = new ItemDto
            {
                id = item.id,
                tenantId = item.tenantId,
                code = item.code,
                categoryId = item.categoryId,
                kitchenId = item.kitchenId,
                title = item.title,
                summary = item.summary,
                price = item.price,
                active = item.active
            };

            return await Task.FromResult(itemDto);

        }

        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = await _db.Items
                .Select(p => new ItemDto
                {
                    id = p.id,
                    tenantId = p.tenantId,
                    code = p.code,
                    categoryId = p.categoryId,
                    kitchenId = p.kitchenId,
                    title = p.title,
                    summary = p.summary,
                    price = p.price,
                    active = p.active
                })
                .ToListAsync();

            return items;
        }

        public async Task<ItemDto> UpdateItem(ItemDto request)
        {
            var item = await _db.Items.FirstOrDefaultAsync(c => c.id == request.id);

            if (item == null)
            {
                return null;
            }

            item.tenantId = request.tenantId;
            item.code = request.code;
            item.categoryId = request.categoryId;
            item.kitchenId = request.kitchenId;
            item.summary = request.summary;
            item.price = request.price;
            item.active = request.active;

            await _db.SaveChangesAsync();

            return request;

        }
    }
}
