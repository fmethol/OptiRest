using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<TableDto>> GetTables(int tenantId);
        Task<TableDto> GetTable(int id);
        Task<TableDto> AddTable(TableDto table);
        Task<TableDto> UpdateTable(TableDto table);
        Task<int> DeleteTable(int id);
    }
}
