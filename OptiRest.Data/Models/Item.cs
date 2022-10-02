using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }
        public int tenantId { get; set; }
        public string code { get; set; }
        public int categoryId { get; set; }
        public int kitchenId { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public double price { get; set; }
        public bool active { get; set; }
        
    }
}
