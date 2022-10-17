using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface ITableShapeService
    {
        Task<TableShapeDto> GetTableShape(int id);
        Task<IEnumerable<TableShapeDto>> GetTableShapes();
    }
}
