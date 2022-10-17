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
    public class ServiceStateService : IServiceStateService
    {
        private readonly AppDbContext _db;

        public ServiceStateService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceStateDto> GetServiceState(int id)
        {
            var serviceState = _db.ServiceStates.FirstOrDefault(ss => ss.Id == id);

            if (serviceState == null)
            {
                return null;
            }

            var serviceStateDto = new ServiceStateDto
            {
                Id = serviceState.Id,
                Name = serviceState.Name,
                Summary = serviceState.Summary
            };

            return await Task.FromResult(serviceStateDto);
        }

        public async Task<IEnumerable<ServiceStateDto>> GetServiceStates()
        {
            var serviceStates = _db.ServiceStates.ToList();

            if (serviceStates == null)
            {
                return null;
            }

            var serviceStateDtos = new List<ServiceStateDto>();

            foreach (var serviceState in serviceStates)
            {
                var serviceStateDto = new ServiceStateDto
                {
                    Id = serviceState.Id,
                    Name = serviceState.Name,
                    Summary = serviceState.Summary
                };

                serviceStateDtos.Add(serviceStateDto);
            }

            return await Task.FromResult(serviceStateDtos);
        }

 

    }
}
