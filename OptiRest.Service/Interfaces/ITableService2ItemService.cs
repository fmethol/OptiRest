using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface ITableService2ItemService
    {
        Task<TableService2ItemDto> AddTableService2Item(TableService2ItemDto tableService2ItemDto);
        Task<int> DeleteTableService2Item(int id);
        Task<TableService2ItemDto> UpdateTableService2Item(TableService2ItemDto tableService2ItemDto);
        Task<TableService2ItemDto> GetTableService2Item(int id);
        Task<IEnumerable<TableService2ItemDto>> GetTableService2Items(int tableServiceId);
        
        Task<IEnumerable<TableService2ItemDto>> GetAllItems(int tenantId);
        Task<IEnumerable<TableService2ItemDto>> GetInProgressItems(int tenantId);
        Task<IEnumerable<TableService2ItemDto>> GetInProgressItemsbyKitchen(int kitchenId);
        Task<int> DeleteTableService2ItemByTableServiceIdAndItemId(int tableServiceId, int itemId);
    }
}