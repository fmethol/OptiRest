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
    public class ServiceItemStateService : IServiceItemStateService
    {
        private readonly AppDbContext _db;
        private List<ServiceItemStateDto> service;

        public ServiceItemStateService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceItemStateDto> GetServiceItemState(int id)
        {
            var serviceItemState = _db.ServiceItemStates.FirstOrDefault(s => s.Id == id);

            if (serviceItemState == null)
            {
                return null;
            }

            var serviceItemStateDto = new ServiceItemStateDto
            {
                Id = serviceItemState.Id,
                Name = serviceItemState.Name,
                Summary = serviceItemState.Summary
            };

            return await Task.FromResult(serviceItemStateDto);
        }

        public async Task<IEnumerable<ServiceItemStateDto>> GetServiceItemStates()
        {
            var serviceItemStates = await _db.ServiceItemStates.Select(s => new ServiceItemStateDto
            {
                Id = s.Id,
                Name = s.Name,
                Summary = s.Summary
            }).ToListAsync();

            return serviceItemStates;
        }


    }
}
