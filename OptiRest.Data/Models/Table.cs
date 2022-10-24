using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class Table
    {
        [Key]
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
        public int? UserId { get; set; }

        public User? User { get; set; }
        public Tenant? Tenant { get; set; }

    }
}
