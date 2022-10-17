using Microsoft.EntityFrameworkCore;
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
    public class TableStateService : ITableStateService
    {
        private readonly AppDbContext _db;
        
        public TableStateService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TableStateDto> GetTableState(int id)
        {
            var tableState = _db.TableStates.FirstOrDefault(ts => ts.Id == id);

            if (tableState == null)
            {
                return null;
            }

            var tableStateDto = new TableStateDto
            {
                Id = tableState.Id,
                Name = tableState.Name,
                Summary = tableState.Summary
            };

            return await Task.FromResult(tableStateDto);


        }

        public async Task<IEnumerable<TableStateDto>> GetTableStates()
        {
            var tableStates = await _db.TableStates.ToListAsync();

            var tableStateDtos = new List<TableStateDto>();
            foreach (var tableState in tableStates)
            {
                var tableStateDto = new TableStateDto
                {
                    Id = tableState.Id,
                    Name = tableState.Name,
                    Summary = tableState.Summary
                };

                tableStateDtos.Add(tableStateDto);
            }

            return await Task.FromResult(tableStateDtos);

        }
    }
}
