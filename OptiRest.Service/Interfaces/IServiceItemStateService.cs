using OptiRest.Data.Models;
using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IServiceItemStateService
    {
        Task<ServiceItemStateDto> GetServiceItemState(int id);
        Task<IEnumerable<ServiceItemStateDto>> GetServiceItemStates();
    }
}
