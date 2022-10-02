using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IAreaService
    {
        Task<IEnumerable<AreaDto>> GetAreas(int tenantId);
        Task<AreaDto> GetArea(int id);
        Task<AreaDto> AddArea(AreaDto area);
        Task<AreaDto> UpdateArea(AreaDto area);
        Task<int> DeleteArea(int id);
    }
}
