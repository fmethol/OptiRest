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
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            if(userDto == null)
            {
                return null;
            }

            var user = new User
            {
                Id = userDto.Id,
                TenantId = userDto.TenantId,
                Username = userDto.Username,
                PasswordHash = userDto.PasswordHash,
                Email = userDto.Email,
                FirstNames = userDto.FirstNames,
                LastName = userDto.LastName,
                RoleId = userDto.RoleId,
                Active = userDto.Active
            };

            await _db.AddAsync(user);
            await _db.SaveChangesAsync();

            userDto.Id = user.Id;

            return userDto;

        }

        public async Task<int> DeleteUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return 0;
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                TenantId = user.TenantId,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                FirstNames = user.FirstNames,
                LastName = user.LastName,
                RoleId = user.RoleId,
                Active = user.Active
            };

            return await Task.FromResult(userDto);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                TenantId = user.TenantId,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                FirstNames = user.FirstNames,
                LastName = user.LastName,
                RoleId = user.RoleId,
                Active = user.Active
            };

            return await Task.FromResult(userDto);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByTenantId(int tenantId)
        {
            var users= await _db.Users.Where(u => u.TenantId == tenantId).ToListAsync();

            if (users == null)
            {
                return null;
            }

            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    TenantId = user.TenantId,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    Email = user.Email,
                    FirstNames = user.FirstNames,
                    LastName = user.LastName,
                    RoleId = user.RoleId,
                    Active = user.Active
                };

                userDtos.Add(userDto);
            }

            return await Task.FromResult(userDtos);

}

        public async Task<UserDto> UpdateUser(UserDto request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
            {
                return null;
            }

            user.Id = request.Id;
            user.TenantId = request.TenantId;
            user.Username = request.Username;
            user.PasswordHash = request.PasswordHash;
            user.Email = request.Email;
            user.FirstNames = request.FirstNames;
            user.LastName = request.LastName;
            user.RoleId = request.RoleId;
            user.Active = request.Active;

            await _db.SaveChangesAsync();

            return request;
        }
    }
}
