using OptiRest.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int id);
        Task<UserDto> GetUserByEmail(string email);
        Task<IEnumerable<UserDto>> GetUsersByTenantId(int tenantId);
        Task<UserDto> CreateUser(UserDto user);
        Task<UserDto> UpdateUser(UserDto user);
        Task<int> DeleteUser(int id);
    }
}
