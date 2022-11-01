using Microsoft.EntityFrameworkCore;
using OptiRest.Data.Context;
using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Services
{
    public class TableService2ItemService : ITableService2ItemService
    {
        private readonly AppDbContext _db;

        public TableService2ItemService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TableService2ItemDto> AddTableService2Item(TableService2ItemDto tableService2ItemDto)
        {
            if (tableService2ItemDto == null)
            {
                return null;
            }

            var tableService2Item = new TableService2Item
            {
                Id = tableService2ItemDto.Id,
                TableServiceId = tableService2ItemDto.TableServiceId,
                ItemId = tableService2ItemDto.ItemId,
                Quantity = tableService2ItemDto.Quantity,
                Price = tableService2ItemDto.Price,
                OrderTime = tableService2ItemDto.OrderTime,
                DeliveryTime = tableService2ItemDto.DeliveryTime,
                ItemStateId = tableService2ItemDto.ItemStateId,
            };

            await _db.AddAsync(tableService2Item);
            await _db.SaveChangesAsync();

            tableService2ItemDto.Id = tableService2Item.Id;

            return tableService2ItemDto;
        }

        public async Task<int> DeleteTableService2Item(int id)
        {
            var tableService2Item = _db.TableService2Items.FirstOrDefault(i => i.Id == id);

            if (tableService2Item == null)
            {
                return 0;
            }

            _db.TableService2Items.Remove(tableService2Item);
            await _db.SaveChangesAsync();

            return tableService2Item.Id;
        }

        public async Task<TableService2ItemDto> UpdateTableService2Item(TableService2ItemDto tableService2ItemDto)
        {
            if (tableService2ItemDto == null)
            {
                return null;
            }

            var tableService2Item = _db.TableService2Items.FirstOrDefault(i => i.Id == tableService2ItemDto.Id);

            if (tableService2Item == null)
            {
                return null;
            }

            tableService2Item.Id = tableService2ItemDto.Id;
            tableService2Item.TableServiceId = tableService2ItemDto.TableServiceId;
            tableService2Item.ItemId = tableService2ItemDto.ItemId;
            tableService2Item.Quantity = tableService2ItemDto.Quantity;
            tableService2Item.Price = tableService2ItemDto.Price;
            tableService2Item.OrderTime = tableService2ItemDto.OrderTime;
            tableService2Item.DeliveryTime = tableService2ItemDto.DeliveryTime;
            tableService2Item.ItemStateId = tableService2ItemDto.ItemStateId;

            await _db.SaveChangesAsync();

            return tableService2ItemDto;
        }

        public async Task<TableService2ItemDto> GetTableService2Item(int id)
        {

            var tableService2Item = _db.TableService2Items.Include(i => i.Item).FirstOrDefault(ts => ts.Id == id);

            if (tableService2Item == null)
            {
                return null;
            }

            var tableService2ItemDto = new TableService2ItemDto
            {
                Id = tableService2Item.Id,
                TableServiceId = tableService2Item.TableServiceId,
                ItemId = tableService2Item.ItemId,
                Quantity = tableService2Item.Quantity,
                Price = tableService2Item.Price,
                OrderTime = tableService2Item.OrderTime,
                DeliveryTime = tableService2Item.DeliveryTime,
                ItemStateId = tableService2Item.ItemStateId,
                //TableService = tableService2Item.TableService,
                Item = tableService2Item.Item
            };

            return tableService2ItemDto;
        }

        public async Task<IEnumerable<TableService2ItemDto>> GetTableService2Items(int tableServiceId)
        {
            var tableService2Items = await _db.TableService2Items.Where(ts => ts.TableServiceId == tableServiceId).Select(ts => new TableService2ItemDto
            {
                Id = ts.Id,
                TableServiceId = ts.TableServiceId,
                ItemId = ts.ItemId,
                Quantity = ts.Quantity,
                Price = ts.Price,
                OrderTime = ts.OrderTime,
                DeliveryTime = ts.DeliveryTime,
                ItemStateId = ts.ItemStateId,
                Item = _db.Items.FirstOrDefault(i => i.Id == ts.ItemId)
            }).ToListAsync();

            return tableService2Items;


        }

        public async Task<IEnumerable<TableService2ItemDto>> GetAllItems(int tenantId)
        {
            var tableServiceItems = await _db.TableService2Items.Where(ts => ts.TableService.TenantId == tenantId).Select(ts => new TableService2ItemDto
            {
                Id = ts.Id,
                TableServiceId = ts.TableServiceId,
                ItemId = ts.ItemId,
                Quantity = ts.Quantity,
                Price = ts.Price,
                OrderTime = ts.OrderTime,
                DeliveryTime = ts.DeliveryTime,
                ItemStateId = ts.ItemStateId
            }).ToListAsync();

            return tableServiceItems;
        }

        public async Task<IEnumerable<TableService2ItemDto>> GetInProgressItems(int tenantId)
        {
            var tableServiceItems = await _db.TableService2Items.Where(ts => ts.TableService.TenantId == tenantId && ts.ItemStateId < 4).Select(ts => new TableService2ItemDto
            {
                Id = ts.Id,
                TableServiceId = ts.TableServiceId,
                ItemId = ts.ItemId,
                Quantity = ts.Quantity,
                Price = ts.Price,
                OrderTime = ts.OrderTime,
                DeliveryTime = ts.DeliveryTime,
                ItemStateId = ts.ItemStateId,
                Item = ts.Item,
                TableService = ts.TableService
            }).ToListAsync();

            return tableServiceItems;
        }

        public async Task<IEnumerable<TableService2ItemDto>> GetInProgressItemsbyKitchen(int kitchenId)
        {
            var tableServiceItems = await _db.TableService2Items.Where(ts => ts.Item.KitchenId == kitchenId && ts.ItemStateId < 4).Select(ts => new TableService2ItemDto
            {
                Id = ts.Id,
                TableServiceId = ts.TableServiceId,
                ItemId = ts.ItemId,
                Quantity = ts.Quantity,
                Price = ts.Price,
                OrderTime = ts.OrderTime,
                DeliveryTime = ts.DeliveryTime,
                ItemStateId = ts.ItemStateId,
                Item = ts.Item,
                TableService = ts.TableService
            }).ToListAsync();

            return tableServiceItems;
        }
    }
}
