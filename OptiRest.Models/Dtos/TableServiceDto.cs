using OptiRest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class TableServiceDto
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int TableId { get; set; }
        public int DinerUserId { get; set; }
        public int Diners { get; set; }
        public int UserId { get; set; }
        public int ServiceStateId { get; set; }
        public DateTime ServiceStart { get; set; }
        public DateTime? ServiceEnd { get; set; }

        public IEnumerable<Item>? Items{ get; set; }
    }
}
