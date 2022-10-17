using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class TableService2Item
    {
        [Key]
        public int Id { get; set; }
        public int TableServiceId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public int ItemStateId { get; set; }

        public TableService? TableService { get; set; }
        public Item? Item { get; set; }
    }
}
