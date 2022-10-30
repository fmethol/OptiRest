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
    public class DinerUserService : IDinerUserService
    {
        private readonly AppDbContext _db;

        public DinerUserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<DinerUserDto> AddDinerUser(DinerUserDto dinerUserDto)
        {
            if (dinerUserDto == null)
            {
                return null;
            }

            // Validando si existe email
            if (_db.DinerUsers.Any(x => x.Email == dinerUserDto.Email))
            {
                return null;
            }

            var dinerUser = new DinerUser
            {
                Id = dinerUserDto.Id,
                Email = dinerUserDto.Email,
                PasswordHash = dinerUserDto.PasswordHash,
                CelPhone = dinerUserDto.CelPhone,
                FirstNames = dinerUserDto.FirstNames,
                LastName = dinerUserDto.LastName
            };

            await _db.AddAsync(dinerUser);
            await _db.SaveChangesAsync();

            dinerUserDto.Id = dinerUser.Id;

            return dinerUserDto;
        }

        public async Task<int> DeleteDinerUser(int id)
        {
            var dinerUser = _db.DinerUsers.FirstOrDefault(du => du.Id == id);

            if (dinerUser == null)
            {
                return 0;
            }

            _db.DinerUsers.Remove(dinerUser);
            await _db.SaveChangesAsync();

            return dinerUser.Id;
        }

        public async Task<DinerUserDto> GetDinerUserById(int id)
        {
            var dinerUser = _db.DinerUsers.FirstOrDefault(du => du.Id == id);

            if (dinerUser == null)
            {
                return null;
            }

            var dinerUserDto = new DinerUserDto
            {
                Id = dinerUser.Id,
                Email = dinerUser.Email,
                PasswordHash = dinerUser.PasswordHash,
                CelPhone = dinerUser.CelPhone,
                FirstNames = dinerUser.FirstNames,
                LastName = dinerUser.LastName
            };

            return await Task.FromResult(dinerUserDto);
        }

        public async Task<DinerUserDto> GetDinerUserByEmail(string email)
        {
            var dinerUser = _db.DinerUsers.FirstOrDefault(du => du.Email == email);

            if (dinerUser == null)
            {
                return null;
            }

            var dinerUserDto = new DinerUserDto
            {
                Id = dinerUser.Id,
                Email = dinerUser.Email,
                PasswordHash = dinerUser.PasswordHash,
                CelPhone = dinerUser.CelPhone,
                FirstNames = dinerUser.FirstNames,
                LastName = dinerUser.LastName
            };

            return await Task.FromResult(dinerUserDto);
        }

 
        public async Task<DinerUserDto> UpdateDinerUser(DinerUserDto dinerUserDto)
        {
            if (dinerUserDto == null)
            {
                return null;
            }

            var dinerUser = _db.DinerUsers.FirstOrDefault(du => du.Id == dinerUserDto.Id);

            if (dinerUser == null)
            {
                return null;
            }

            dinerUser.Id = dinerUserDto.Id;
            dinerUser.Email = dinerUserDto.Email;
            dinerUser.PasswordHash = dinerUserDto.PasswordHash;
            dinerUser.CelPhone = dinerUserDto.CelPhone;
            dinerUser.FirstNames = dinerUserDto.FirstNames;
            dinerUser.LastName = dinerUserDto.LastName;

            await _db.SaveChangesAsync();

            return dinerUserDto;
        }

        
    }
}
