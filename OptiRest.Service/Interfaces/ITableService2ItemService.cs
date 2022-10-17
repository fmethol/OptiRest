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
    }
}