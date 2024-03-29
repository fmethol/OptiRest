﻿using OptiRest.Models.Dtos;
using OptiRest.Data.Models;
using OptiRest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiRest.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace OptiRest.Service.Services
{
    public class TableServiceService : ITableServiceService
    {
        private readonly AppDbContext _db;

        public TableServiceService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TableServiceDto> AddTableService(TableServiceDto tableServiceDto)
        {
            if (tableServiceDto == null)
            {
                return null;
            }

            var tableService = new OptiRest.Data.Models.TableService
            {
                Id = tableServiceDto.Id,
                TenantId = tableServiceDto.TenantId,
                TableId = tableServiceDto.TableId,
                DinerUserId = tableServiceDto.DinerUserId,
                Diners = tableServiceDto.Diners,
                UserId = tableServiceDto.UserId,
                ServiceStateId = tableServiceDto.ServiceStateId,
                ServiceStart = tableServiceDto.ServiceStart,
                ServiceEnd = tableServiceDto.ServiceEnd,
                PaymentMethod = tableServiceDto.PaymentMethod,
                PaymentReference = tableServiceDto.PaymentReference,
                Comment = tableServiceDto.Comment,
            };

            _db.Tables.FirstOrDefault(t => t.Id == tableServiceDto.TableId).StateId = 2;

            await _db.AddAsync(tableService);
            await _db.SaveChangesAsync();

            tableServiceDto.Id = tableService.Id;

            return tableServiceDto;

        }

        public async Task<int> DeleteTableService(int id)
        {
            var tableService = _db.TableServices.FirstOrDefault(ts => ts.Id == id);

            if (tableService == null)
            {
                return 0;
            }

            _db.TableServices.Remove(tableService);
            await _db.SaveChangesAsync();

            return id;
        }

        public async Task<TableServiceDto> GetTableService(int id)
        {
            var tableService = _db.TableServices.FirstOrDefault(ts => ts.Id == id);

            if (tableService == null)
            {
                return null;
            }

            var tableServiceDto = new TableServiceDto
            {
                Id = tableService.Id,
                TenantId = tableService.TenantId,
                TableId = tableService.TableId,
                DinerUserId = tableService.DinerUserId,
                Diners = tableService.Diners,
                UserId = tableService.UserId,
                ServiceStateId = tableService.ServiceStateId,
                ServiceStart = tableService.ServiceStart,
                ServiceEnd = tableService.ServiceEnd,
                PaymentMethod = tableService.PaymentMethod,
                PaymentReference = tableService.PaymentReference,
                Comment = tableService.Comment,
                Items = _db.TableService2Items.Where(ts2i => ts2i.TableServiceId == tableService.Id).Select(ts2i => ts2i.Item).ToList()
            };
 
            return await Task.FromResult(tableServiceDto);
        }

        public async Task<IEnumerable<TableServiceDto>> GetTableServices(int tenantId, bool active = true)
        {
            var tableServices =  await _db.TableServices
                .Where(ts => ts.TenantId == tenantId)
                .Where(ts => active ? ts.ServiceStateId < 4 : true)
                .Select(ts => new TableServiceDto
                {
                    Id = ts.Id,
                    TenantId = ts.TenantId,
                    TableId = ts.TableId,
                    DinerUserId = ts.DinerUserId,
                    Diners = ts.Diners,
                    UserId = ts.UserId,
                    ServiceStateId = ts.ServiceStateId,
                    ServiceStart = ts.ServiceStart,
                    ServiceEnd = ts.ServiceEnd,
                    //Items = _db.TableService2Items.Select(i => i.Item).ToList()
                }).ToListAsync();


            return tableServices;

        }

        public async Task<TableServiceDto> UpdateTableService(TableServiceDto tableServiceDto)
        {
            var tableService = _db.TableServices.FirstOrDefault(ts => ts.Id == tableServiceDto.Id);

            if (tableService == null)
            {
                return null;
            }

            tableService.Id = tableServiceDto.Id;
            tableService.TenantId = tableServiceDto.TenantId;
            tableService.TableId = tableServiceDto.TableId;
            tableService.DinerUserId = tableServiceDto.DinerUserId;
            tableService.Diners = tableServiceDto.Diners;
            tableService.UserId = tableServiceDto.UserId;
            tableService.ServiceStateId = tableServiceDto.ServiceStateId;
            tableService.ServiceStart = tableServiceDto.ServiceStart;
            tableService.ServiceEnd = tableServiceDto.ServiceEnd;
            tableService.PaymentMethod = tableServiceDto.PaymentMethod;
            tableService.PaymentReference = tableServiceDto.PaymentReference;
            tableService.Comment = tableServiceDto.Comment;
            
            if (tableServiceDto.ServiceStateId == 4)
            {
                var table = _db.Tables.FirstOrDefault(t => t.Id == tableServiceDto.TableId);
                table.StateId = 5;
                tableService.ServiceEnd = DateTime.Now;
            }

            await _db.SaveChangesAsync();

            return tableServiceDto;

        }
    }
}
