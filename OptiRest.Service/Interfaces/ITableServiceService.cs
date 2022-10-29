using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface ITableServiceService
    {
        Task<IEnumerable<TableServiceDto>> GetTableServices(int tenantId, bool active = true);
        Task<TableServiceDto> GetTableService(int id);
        Task<TableServiceDto> AddTableService(TableServiceDto tableServiceDto);
        Task<TableServiceDto> UpdateTableService(TableServiceDto tableServiceSto);
        Task<int> DeleteTableService(int id);
    }
}
