using OptiRest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class TableDto
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int ShapeId { get; set; }
        public int StateId { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int UserId { get; set; }

        public User? User { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
