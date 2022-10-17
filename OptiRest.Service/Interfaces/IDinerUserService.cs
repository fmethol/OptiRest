using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IDinerUserService
    {
        Task<DinerUserDto> GetDinerUserById(int id);
        Task<DinerUserDto> GetDinerUserByEmail(string email);
        Task<DinerUserDto> AddDinerUser(DinerUserDto dinerUser);
        Task<DinerUserDto> UpdateDinerUser(DinerUserDto dinerUser);
        Task<int> DeleteDinerUser(int id);

    }
}
