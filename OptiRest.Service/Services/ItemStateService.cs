using Microsoft.AspNetCore.Http.Features;
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
    public class ItemStateService : IItemStateService
    {
        private readonly AppDbContext _db;

        public ItemStateService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ItemStateDto> GetItemState(int id)
        {
            var itemState = _db.ItemStates.FirstOrDefault(its => its.Id == id);

            if (itemState == null)
            {
                return null;
            }

            var itemStateDto = new ItemStateDto
            {
                Id = itemState.Id,
                Name = itemState.Name,
                Summary = itemState.Summary
            };

            return await Task.FromResult(itemStateDto);

        }

        public async Task<IEnumerable<ItemStateDto>> GetItemStates()
        {
            var itemStates = _db.ItemStates.ToList();

            if (itemStates == null)
            {
                return null;
            }

            var itemStateDtos = new List<ItemStateDto>();

            foreach (var itemState in itemStates)
            {
                var itemStateDto = new ItemStateDto
                {
                    Id = itemState.Id,
                    Name = itemState.Name,
                    Summary = itemState.Summary
                };

                itemStateDtos.Add(itemStateDto);
            }

            return await Task.FromResult(itemStateDtos);
        }
    }
}
