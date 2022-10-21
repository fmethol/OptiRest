using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OptiRest.Data.Context;
using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using OptiRest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table = OptiRest.Data.Models.Table;

namespace OptiRest.Service.Services
{
    public class TableService : ITableService
    {
        private readonly AppDbContext _db;
        
        public TableService(AppDbContext db)
        {
            _db = db;                
        }

        public async Task<TableDto> AddTable(TableDto tableDto)
        {
            if (tableDto == null)
            {
                return null;
            }

            var table = new Table
            {
                Id = tableDto.Id,
                TenantId = tableDto.TenantId,
                AreaId = tableDto.AreaId,
                Name = tableDto.Name,
                Length = tableDto.Length,
                Width = tableDto.Width,
                ShapeId = tableDto.ShapeId,
                StateId = tableDto.StateId,
                PosX = tableDto.PosX,
                PosY = tableDto.PosY,
                UserId = tableDto.UserId
            };

            await _db.AddAsync(table);
            await _db.SaveChangesAsync();

            tableDto.Id = table.Id;

            return tableDto;
        }

        public async Task<int> DeleteTable(int id)
        {
            var table = _db.Tables.FirstOrDefault(t => t.Id == id);

            if (table == null)
            {
                return 0;
            }

            _db.Tables.Remove(table);
            await _db.SaveChangesAsync();

            return table.Id;
        }

        public async Task<TableDto> GetTable(int id)
        {
            var table =  _db.Tables.FirstOrDefault(t => t.Id == id);

            if (table == null)
            {
                return null;
            }

            var tableDto = new TableDto
            {
                Id = table.Id,
                TenantId = table.TenantId,
                AreaId = table.AreaId,
                Name = table.Name,
                Length = table.Length,
                Width = table.Width,
                ShapeId = table.ShapeId,
                StateId = table.StateId,
                PosX = table.PosX,
                PosY = table.PosY,
                UserId = table.UserId,
                User = _db.Users.FirstOrDefault(u => u.Id == table.UserId),
                Tenant = _db.Tenants.Include(t => t.BusinessConfig).FirstOrDefault(t => t.Id == table.TenantId)
            };

            return await Task.FromResult(tableDto);
        }

        public async Task<IEnumerable<TableDto>> GetTables()
        {
            var tables = await _db.Tables.ToListAsync();

            if (tables == null)
            {
                return null;
            }

            var tableDtos = new List<TableDto>();

            foreach (var table in tables)
            {
                tableDtos.Add(new TableDto
                {
                    Id = table.Id,
                    TenantId = table.TenantId,
                    AreaId = table.AreaId,
                    Name = table.Name,
                    Length = table.Length,
                    Width = table.Width,
                    ShapeId = table.ShapeId,
                    StateId = table.StateId,
                    PosX = table.PosX,
                    PosY = table.PosY,
                    UserId = table.UserId
                });
            }

            return await Task.FromResult(tableDtos);
        }

        public async Task<TableDto> UpdateTable(TableDto request)
        {
            var table = _db.Tables.FirstOrDefault(t => t.Id == request.Id);
            
            if (request == null)
            {
                return null;
            }

            table.Name = request.Name;
            table.Length = request.Length;
            table.Width = request.Width;
            table.ShapeId = request.ShapeId;
            table.StateId = request.StateId;
            table.PosX = request.PosX;
            table.PosY = request.PosY;
            table.UserId = request.UserId;

            await _db.SaveChangesAsync();

            return request;
        }

      


    }
   
}



