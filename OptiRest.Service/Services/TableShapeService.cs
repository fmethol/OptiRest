using OptiRest.Data.Context;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Services
{
    public class TableShapeService : ITableShapeService
    {
        private readonly AppDbContext _db;

        public TableShapeService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TableShapeDto> GetTableShape(int id)
        {
            var tableShape = _db.TableShapes.FirstOrDefault(ts => ts.Id == id);

            if (tableShape == null)
            {
                return null;
            }

            var tableShapeDto = new TableShapeDto
            {
                Id = tableShape.Id,
                Name = tableShape.Name
            };

            return await Task.FromResult(tableShapeDto);
        }

        public async Task<IEnumerable<TableShapeDto>> GetTableShapes()
        {
            var tableShapes = _db.TableShapes.ToList();

            if (tableShapes == null)
            {
                return null;
            }

            var tableShapeDtos = new List<TableShapeDto>();

            foreach (var tableShape in tableShapes)
            {
                var tableShapeDto = new TableShapeDto
                {
                    Id = tableShape.Id,
                    Name = tableShape.Name
                };

                tableShapeDtos.Add(tableShapeDto);
            }

            return await Task.FromResult(tableShapeDtos);
        }




    }
}
