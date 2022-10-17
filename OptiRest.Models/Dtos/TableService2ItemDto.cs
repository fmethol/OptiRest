using OptiRest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class TableService2ItemDto
    {
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
