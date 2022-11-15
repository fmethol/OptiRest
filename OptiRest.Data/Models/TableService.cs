using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class TableService
    {
        [Key]
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int TableId { get; set; }
        public int DinerUserId { get; set; }
        public int Diners { get; set; }
        public int UserId { get; set; }
        public int ServiceStateId { get; set; }
        public DateTime ServiceStart { get; set; }
        public DateTime? ServiceEnd { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentReference { get; set; }
        public string? Comment { get; set; }

        public IEnumerable<TableService2Item>? TableService2Items { get; set; }

    }
}
