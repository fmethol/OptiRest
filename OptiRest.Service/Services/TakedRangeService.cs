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

namespace OptiRest.Service.Services
{
    public class TakedRangeService : ITakedRangeService
    {
        private readonly AppDbContext _db;

        public TakedRangeService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TakedRangeDto> CreateTakedRange(TakedRangeDto takedRangeDto)
        {
            if (takedRangeDto == null)
            {
                return null;
            }

            var takedRange = new TakedRange
            {
                takedRangeId = takedRangeDto.takedRangeId,
                tenantId = takedRangeDto.tenantId,
                name = takedRangeDto.name,
                summary = takedRangeDto.summary
            };

            await _db.AddAsync(takedRange);
            await _db.SaveChangesAsync();

            takedRangeDto.takedRangeId = takedRange.takedRangeId;


            return takedRangeDto;
        }

        public async Task<int> DeleteTakedRange(int id)
        {
            var takedRange = await _db.TakedRanges.FirstOrDefaultAsync(c => c.takedRangeId == id);

            if (takedRange == null)
            {
                return 0;
            }

            _db.TakedRanges.Remove(takedRange);
            await _db.SaveChangesAsync();

            return takedRange.takedRangeId;
        }

        public async Task<TakedRangeDto> GetTakedRange(int id)
        {
            var takedRange = _db.TakedRanges.FirstOrDefault(p => p.takedRangeId == id);

            var takedRangeDto = new TakedRangeDto
            {
                takedRangeId = takedRange.takedRangeId,
                tenantId = takedRange.tenantId,
                name = takedRange.name,
                summary = takedRange.summary
            };

            return await Task.FromResult(takedRangeDto);
        }

        public async Task<IEnumerable<TakedRangeDto>> GetTakedRanges()
        {
            var takedRanges = await _db.TakedRanges
                .Select(p => new TakedRangeDto
                {
                    takedRangeId = p.takedRangeId,
                    tenantId = p.tenantId,
                    name = p.name,
                    summary = p.summary
                })
                .ToListAsync();

            return takedRanges;

        }

        public async Task<TakedRangeDto> UpdateTakedRange(TakedRangeDto request)
        {
            var takedRange = await _db.TakedRanges.FirstOrDefaultAsync(c => c.takedRangeId == request.takedRangeId);

            if (takedRange == null)
            {
                return null;
            }

            takedRange.tenantId = request.tenantId;
            takedRange.name = request.name;
            takedRange.summary = request.summary;

            await _db.SaveChangesAsync();

            return request;

        }

    }
}
