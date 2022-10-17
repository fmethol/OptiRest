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
using Table = OptiRest.Data.Models.Table;

namespace OptiRest.Service.Services
{
    public class AreaService : IAreaService
    {
        private readonly AppDbContext _db;

        public AreaService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<AreaDto> AddArea(AreaDto areaDto)
        {
            if(areaDto == null)
            {
                return null;
            }

            var area = new Area
            {
                Id = areaDto.Id,
                TenantId = areaDto.TenantId,
                Name = areaDto.Name,
                Width = areaDto.Width,
                Length = areaDto.Length,
                Summary = areaDto.Summary
            };

            await _db.AddAsync(area);
            await _db.SaveChangesAsync();

            areaDto.Id = area.Id;

            return areaDto;
        }

        public async Task<int> DeleteArea(int id)
        {
            var area = _db.Areas.Include(a => a.Tables).FirstOrDefault(a => a.Id == id);

            if (area == null)
            {
                return 0;
            }

            _db.Areas.Remove(area);
            await _db.SaveChangesAsync();

            return area.Id;
        }

        public async Task<AreaDto> GetArea(int id)
        {
            var area = _db.Areas.FirstOrDefault(a => a.Id == id);

            if (area == null)
            {
                return null;
            }

            var areaDto = new AreaDto
            {
                Id = area.Id,
                TenantId = area.TenantId,
                Name = area.Name,
                Width = area.Width,
                Length = area.Length,
                Summary = area.Summary,
                Tables = area.Tables
            };

            return await Task.FromResult(areaDto);
        }

        public async Task<IEnumerable<AreaDto>> GetAreas(int tenantId)
        {

            var areas = await _db.Areas
                .Where(a => a.TenantId == tenantId)
                .Select(a => new AreaDto
                {
                    Id = a.Id,
                    TenantId = a.TenantId,
                    Name = a.Name,
                    Width = a.Width,
                    Length = a.Length,
                    Summary = a.Summary,
                    Tables = a.Tables
                })
                .ToListAsync();

            return areas;
        }

        public async Task<AreaDto> UpdateArea(AreaDto request)
        {
            var area = _db.Areas.FirstOrDefault(a => a.Id == request.Id);

            if (area == null)
            {
                return null;
            }

            area.Name = request.Name;
            area.Width = request.Width;
            area.Length = request.Length;
            area.Summary = request.Summary;

            await _db.SaveChangesAsync();

            return request;
        }
    }
}
